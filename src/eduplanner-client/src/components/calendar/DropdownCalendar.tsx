import {useState} from 'react';
import {FaCaretDown, FaCaretUp} from "react-icons/fa6";
import {Link, useParams} from "react-router";

function DropdownCalendar({weeks, selectedWeekId, type}: any) {
  const params = useParams();
  const [isOpen, setIsOpen] = useState(false);
  
  const getWeekName = (weeks, weekId) => {
    return weeks.find((week) => week.id === weekId);
  }
  
  return (
    <div className="relative text-sm">
      <button
        onClick={() => setIsOpen(!isOpen)}
        className="bg-primary-dark p-3  w-full flex gap-5 items-center justify-center font-bold text-white tracking-wide border-4 border-transparent  hover:opacity-80">
        <span>Tydzień: {selectedWeekId? getWeekName(weeks, selectedWeekId): ""}</span>
        {!isOpen ? (<FaCaretDown/>): (<FaCaretUp/>)}
      </button>
      
      {isOpen && (
        <div className="bg-primary-light absolute mt-2 flex flex-col items-start p-2 w-full z-50">
          {weeks.map((group) => {
            return (
                <Link key={group.id} to={`/${type}/${params.typeId}/week/${group.id}`} onClick={() => {
                  setIsOpen(!isOpen);
                }} className="text-sm w-full text-white font-bold p-1 hover:opacity-80">{group.description}</Link>
              )
          })}
        </div>
      )}
      
    </div>
  );
}

export default DropdownCalendar;
