import '@schedule-x/theme-default/dist/calendar.css'
import "../../components/calendar/Calendar.css"
import {useEffect, useRef, useState} from "react";
import DropdownCalendar from "../../components/calendar/DropdownCalendar.jsx";
import Calendar from "../../components/calendar/Calendar.jsx";
import {createCalendarControlsPlugin} from "@schedule-x/calendar-controls";
import ApiService from "../../services/ApiService.js";
import {useParams} from "react-router";

const TeacherView = () => {
  const {typeId, weekId} = useParams();
  const contentRef = useRef(null);
  const [events, setEvents] = useState([]);
  const controls = useState(() => createCalendarControlsPlugin())[0]
  const[date, setDate] = useState(null);

  
  const formatDate = (stringDate, addMinutes) => {
    
    const now = new Date(stringDate);
    now.setMinutes( addMinutes);
    
    const year = now.getFullYear();
    const month = String(now.getMonth() + 1).padStart(2, "0"); // Dodaje wiodące zero
    const day = String(now.getDate()).padStart(2, "0");
    const hours = String(now.getHours()).padStart(2, "0");
    const minutes = String(now.getMinutes() ).padStart(2, "0");
    return `${year}-${month}-${day} ${hours}:${minutes}`;
  };
  const fetchData = async (id) => {
    const response = ApiService.getTeachersTimes(typeId, weekId, id);
    const courses = []
    response.then((response) => {
      console.log(response);
      if(response.courses){
        response.courses.forEach(course => {
          courses.push({
            id: course.id,
            title: course.course.shortcut,
            fullTitle: course.course.name,
            type: course.course.type,
            start: formatDate(course.startDate, course.minutesStart),
            end: formatDate(course.startDate, course.minutesEnd),
            location: (course.rooms.length > 0 ? course.rooms[0].nr  : "Nie podano"),
            description: course.groups.map((group) => group.shortcut).join(", ")
          });
        })
      }
      if(response.reservations){
        response.reservations.forEach(reservation => {
          courses.push({
            id: reservation.id,
            title: reservation.type || reservation.description,
            fullTitle: reservation.description,
            type: reservation.type,
            start: formatDate(reservation.startDate, reservation.minutesStart),
            end: formatDate(reservation.startDate, reservation.minutesEnd),
            location: (reservation.rooms.length > 0 ? reservation.rooms[0].nr  : "Nie podano"),
            description: reservation.groups.map((group) => group.shortcut).join(", ")
          });
        });
      }
      setEvents((prevState) => [...prevState, ...courses]);
      
    })
  }
  useEffect(() => {
    setEvents([]);
  }, [typeId]);
  useEffect(() => {
    fetchData(2);
    fetchData(3);
    fetchData(4);
    if(date) controls.setDate(date)
  }, [weekId]);
  
  useEffect(() => {
    const fetchWeek = async () => {
      const response = ApiService.getWeekById(weekId);
      response.then((response) => {
        var date = new Date(response.startWeek);
        var formattedDate = `${date.getFullYear()}-${String(date.getMonth() + 1).padStart(2, '0')}-${String(date.getDate()).padStart(2, "0")}`;
        setDate(formattedDate);
      })
    }
    fetchWeek();
  },[weekId])
  
  useEffect(() => {
    if(date) controls.setDate(date)
  },[date])
  

  return (
    <div className="overflow-auto s">
      <div className="pb-4 flex flex-row ">
        <DropdownCalendar type="teacher" date={date} setEvents={setEvents} />
      </div>
      <div ref={contentRef}>
        
        <Calendar events={events} controls={controls}  date={date} />
      </div>
    </div>
  );
};

export default TeacherView;
