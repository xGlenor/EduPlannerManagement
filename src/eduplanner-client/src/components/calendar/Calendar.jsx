import {ScheduleXCalendar, useCalendarApp} from "@schedule-x/react";
import {createViewDay, createViewWeek} from "@schedule-x/calendar";
import '@schedule-x/theme-default/dist/calendar.css'
import {createEventModalPlugin} from "@schedule-x/event-modal";
import "./Calendar.css"
import { useState} from "react";
import {createEventsServicePlugin} from "@schedule-x/events-service";

import {createCurrentTimePlugin} from "@schedule-x/current-time";


const Calendar = ({events, controls}) => {
  const eventModal = createEventModalPlugin()
  const eventsService = useState(() => createEventsServicePlugin())[0]
  
  const calendar = useCalendarApp({
    theme: 'shadcn',
    views: [createViewWeek(), createViewDay()],
    locale: 'pl-PL',
    defaultView: createViewWeek.name,
    selectedDate: "2024-09-23",
    minDate: '2024-09-23',
    maxDate: '2025-02-17',
    dayBoundaries: {
      start: '07:00',
      end: '21:00',
    },
    weekOptions: {
      gridHeight: 700,
      nDays: 7,
    },
    plugins: [eventModal, eventsService, createCurrentTimePlugin(), controls],
  })
  
  
  
  eventModal.close();
  
  if(events){
    eventsService.set(events);
  }
  
  return (
    <div>
      <ScheduleXCalendar calendarApp={calendar}/>
    </div>
  );
}

export default Calendar;
