import {useEffect, useState} from "react";
import ApiService from "../services/ApiService.js";
import {Link} from "react-router";
import {FaSearch} from "react-icons/fa";


const Search = () => {
  const [searchValue, setSearchValue] = useState('');
  
  const [groups, setGroups] = useState([]);
  const [teachers, setTeachers] = useState([]);
  const [rooms, setRooms] = useState([]);
  
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
          className="bg-transparent focus:outline-none outline-none ring-0 w-auto text-ubb-gray border-none p-0"
          placeholder={"Szukaj..."}/>
      </div>
      {(groups.length > 0 || teachers.length > 0 || rooms.length > 0) &&  (
        <div className="bg-primary-light absolute flex flex-col items-start p-2 w-full">
          {groups && groups.map((group) => {
            return (
              <Link to={`/group/${group.id}`} key={group.id}>{group.shortcut}</Link>
            )
          })}
        </div>
      )}
    </div>
    
  );
};

export default Search;
