import { useCalendarApp, ScheduleXCalendar } from '@schedule-x/react'
import '@schedule-x/theme-shadcn/dist/index.css'
import {
  createViewWeek,
  createViewDay
} from '@schedule-x/calendar'

import "./Groups.css"
import {createEventModalPlugin} from "@schedule-x/event-modal";
import {createResizePlugin} from "@schedule-x/resize";
import EventGrid from "../../components/calendar/EventGrid.jsx";

const Groups = () => {
  const eventModal = createEventModalPlugin()
  
  const calendar = useCalendarApp({
    theme: 'shadcn',
    views: [createViewWeek(), createViewDay()],
    locale: 'pl-PL',
    defaultView: createViewWeek.name,
    
    dayBoundaries: {
      start: '07:00',
      end: '21:00',
    },
    plugins: [eventModal, createResizePlugin(30)],
    events: [

      {
        title: "Ripw, wyk",
        description: "Wyk wyk",
        description2: "dasdasasd",
        people: ["Jmr", "Test"],
        start: "2025-01-20 10:15",
        end: "2025-01-20 11:45",
        id: "98d85d98541f",
      }, {
        title: "Sipping Aperol Spritz on the beach",
        start: "2025-01-23 12:00",
        end: "2025-01-23 15:20",
        id: "0d13aae3b8a1",
      },
      {
        title: "Sipping Aperol Spritz on the beach",
        start: "2025-01-23 13:00",
        end: "2025-01-23 17:20",
        id: "0d13aae3b8a1",
      },
    ]
  })
  
  eventModal.close();
  
  return (
    <div className="overflow-auto">
      <ScheduleXCalendar
        calendarApp={calendar}
        customComponents={{
          timeGridEvent: EventGrid,

        }}/>
    </div>
  );
};

export default Groups;
