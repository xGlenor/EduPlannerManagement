import {Link, useParams} from "react-router";
import { useEffect, useState} from "react";
import Dropdown from "../../components/Dropdown.tsx";
import ApiService from "../../services/ApiService.ts";


const TeacherTree = () => {
  const {id} = useParams();
  const [loading, setLoading] = useState(true);
  const [groups, setGroups] = useState<any[]>([]);
  const groupdId = id || 0;
  
  useEffect(() => {
    
    const fetchGroups = async () => {
      const response = ApiService.getGroupsById('teachers',groupdId as number);
      response.then((data) => {
        setGroups(data.nodes);
      }).catch((error) => {
        console.error("Błąd podczas pobierania danych:", error);
      }).finally(() => {
        setLoading(false);
      })
    };
    fetchGroups();
  }, [id]);
  
  
  if (loading) {
    return <div>Ładowanie danych...</div>
  }
  
  return (
    <div className="flex flex-row gap-6 w-full h-full flex-wrap">
      {groups.map((group) => (
        <div key={group.id} className="bg-primary-dark size-52 flex flex-col">
          <Link to={`${group.hasChildren ? `/teacherstree/${group.id}` : '#'}`} className="w-full flex-1 flex flex-col items-center text-center justify-center gap-2 font-bold text-white p-4">
            {group.name}
          </Link>
          {group.groups.length > 0 && (
            <div className="px-3 pb-3">
              <Dropdown title="Wybierz nauczyciela:" groups={group.groups} type="teacher"/>
            </div>
          )}
        </div>
      ))}
    </div>
  
  );
};

export default TeacherTree;
