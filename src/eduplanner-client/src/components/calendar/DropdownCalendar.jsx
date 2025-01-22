import {useEffect, useState} from 'react';
import {FaCaretDown, FaCaretUp} from "react-icons/fa6";
import {Link, useNavigate, useParams} from "react-router";
import ApiService from "../../services/ApiService.js";

function DropdownCalendar( {title, date, setEvents, type}) {
  const params = useParams();
  const [isOpen, setIsOpen] = useState(false);
  const [weeks, setWeeks] = useState(0);
  const formatDate = (stringDate) => {
    const now = new Date(stringDate);

    const year = now.getFullYear();
    const month = String(now.getMonth() + 1).padStart(2, "0"); // Dodaje wiodące zero
    const day = String(now.getDate()).padStart(2, "0");

    return `${year}-${month}-${day} `;
  };
  
  useEffect(() => {
    const getWeekId = () => {
      const response = ApiService.getWeeks();
      response.then(data => {
        setWeeks(data);
      });
    }
    getWeekId()
  }, []);
  
  return (
    <div className="relative text-sm">
      <button
        onClick={() => setIsOpen(!isOpen)}
        className="bg-primary-dark p-3  w-full flex gap-5 items-center justify-center font-bold text-white tracking-wide border-4 border-transparent  hover:opacity-80">
        <span>Tydzień: {date? date: title}</span>
        {!isOpen ? (<FaCaretDown/>): (<FaCaretUp/>)}
      </button>
      
      {isOpen && (
        <div className="bg-primary-light absolute mt-2 flex flex-col items-start p-2 w-full z-50">
          {weeks.map((group) => {
            return (
                <Link key={group.id} to={`/${type}/${params.typeId}/week/${group.id}`} onClick={() => {
                  setEvents([]); setIsOpen(!isOpen);
                }} className="text-sm w-full text-white font-bold p-1 hover:opacity-80">{group.description}</Link>
              )
          })}
        </div>
      )}
      
    </div>
  );
}

export default DropdownCalendar;
