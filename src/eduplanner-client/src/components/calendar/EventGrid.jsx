import * as PropTypes from "prop-types";
import {Component} from "react";
import {FaRegClock, FaUser} from "react-icons/fa";

class EventGrid extends Component {
  render() {
    let {calendarEvent} = this.props;
    const start = new Date(calendarEvent.start).toLocaleTimeString('pl-PL', {hour: '2-digit', minute: '2-digit'});
    const end = new Date(calendarEvent.end).toLocaleTimeString('pl-PL', {hour: '2-digit', minute: '2-digit'});
    return (
      <div className="bg-primary-dark text-white p-2 h-full flex flex-col gap-1">
        <div className="font-bold">{calendarEvent.title}</div>
        <div className="flex items-center gap-1"><FaRegClock />  {start} - {end}</div>
        <div className="flex items-center gap-1">
          <FaUser />
          {calendarEvent.people ? calendarEvent.people.join(", ") : null}
        </div>
        <div className="flex items-center gap-1">
          <FaUser />
          {calendarEvent.people ? calendarEvent.people.join(", ") : null}
        </div>
      </div>
    );
  }
}

EventGrid.propTypes = {calendarEvent: PropTypes.any}

export default EventGrid;
