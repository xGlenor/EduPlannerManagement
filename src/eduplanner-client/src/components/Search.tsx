import {useEffect, useState} from "react";
import ApiService from "../services/ApiService.ts";
import {Link} from "react-router";
import {FaSearch} from "react-icons/fa";


const Search = () => {
  const [searchValue, setSearchValue] = useState('');
  
  const [groups, setGroups] = useState<any[]>([]);
  const [teachers, setTeachers] = useState<any[]>([]);
  const [rooms, setRooms] = useState<any[]>([]);
  const [week, setWeek] = useState<number>(0);
  
  useEffect(() => {
    const getWeekId = () => {
      const date = new Date();
      const formattedDAte = `${date.getFullYear()}.${date.getMonth() +1}.${date.getDate()}`;
      const response = ApiService.getCurrentWeek(formattedDAte);
      response.then(data => {
        setWeek(data.id);
      });
    }
    getWeekId()
  }, []);
  
  
  useEffect( () => {
    const fetchGroups = async () => {
      if(searchValue.trim() === '') {
        setGroups([]);
        return;
      }
      const response = ApiService.search("groups",searchValue);
      response.then((data) => {
        setGroups(data);
      })
    }
    fetchGroups();
    
    const fetchTeachers = async () => {
      if(searchValue.trim() === '') {
        setTeachers([]);
        return;
      }
      const response = ApiService.search("teachers",searchValue);
      response.then((data) => {
        setTeachers(data);
      })
    }
    fetchTeachers();
    
    const fetchRooms = async () => {
      if(searchValue.trim() === '') {
        setRooms([]);
        return;
      }
      const response = ApiService.search("rooms",searchValue);
      response.then((data) => {
        setRooms(data);
      })
    }
    fetchRooms();
  }, [searchValue]);
  
  
  return (
    <div className="relative">
      <div className="flex items-center rounded-2xl bg-ubb-white gap-3 px-4 py-2">
        <FaSearch className="text-ubb-gray text-lg block float-left cursor-pointer"/>
        <input
          type={"search"}
          value={searchValue}
          onChange={(e) => setSearchValue(e.target.value)}
          className="bg-transparent focus:outline-hidden outline-hidden ring-0 w-auto text-ubb-gray border-none p-0"
          placeholder={"Szukaj..."}/>
      </div>
      {(groups.length > 0 || teachers.length > 0 || rooms.length > 0) &&  (
        <div className="bg-primary-light absolute mt-5 flex flex-col items-start p-2 w-full max-h-72 overflow-y-visible overflow-auto z-50">
          
          {groups && groups.map((group) => {
            return (
              <Link className="p-1 text-black hover:text-gray-600" to={`/group/${group.id}/week/${week}`} key={group.id}>{group.shortcut}</Link>
            )
          })}
          
          {teachers && teachers.map((teacher) => {
            return (
              <Link className="p-1 text-black hover:text-gray-600" to={`/teacher/${teacher.id}/week/${week}`} key={teacher.id}>{`${teacher.name} ${teacher.surname}`}</Link>
            )
          })}
          
          {rooms && rooms.map((room) => {
            return (
              <Link className="p-1 text-black hover:text-gray-600" to={`/room/${room.id}/week/${week}`} key={room.id}>{room.nr}</Link>
            )
          })}
        </div>
      )}
    </div>
    
  );
};

export default Search;
