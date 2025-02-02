const BASE_URL = 'http://localhost:8081/api';

async function getGroupsById(type, id = 0) {
  const response = await fetch(`${BASE_URL}/${type}/tree?parentId=${id}`);
  return await response.json();
}
async function getCurrentWeek(date) {
  const response = await fetch(`${BASE_URL}/weeks/${date}`);
  return await response.json();
}
async function getWeekById(id) {
  const response = await fetch(`${BASE_URL}/weeks/${id}`);
  return await response.json();
}
async function getWeeks(){
  const response = await fetch(`${BASE_URL}/weeks`);
  return await response.json();
}
async function getGroupsTimes(groupdId, weekId, weekTypeId){
  const response = await fetch(`${BASE_URL}/groups/times?groupId=${groupdId}&weekId=${weekId}&weekTypeId=${weekTypeId}`);
  const data = await response.json();
  
  return data;
}
async function getTeachersTimes(teacherId, weekId, weekTypeId){
  const response = await fetch(`${BASE_URL}/teachers/times?teacherId=${teacherId}&weekId=${weekId}&weekTypeId=${weekTypeId}`);
  const data = await response.json();
  
  return data;
}
async function getRoomsTimes(roomId, weekId, weekTypeId){
  const response = await fetch(`${BASE_URL}/rooms/times?roomId=${roomId}&weekId=${weekId}&weekTypeId=${weekTypeId}`);
  const data = await response.json();
  
  return data;
}
async function search(type, filter) {
  const response = await fetch(`${BASE_URL}/${type}/search?name=${filter}`);
  const data = await response.json();
  return data;
}
async function getWeekId() {
  const date = new Date();
  const formattedDAte = `${date.getFullYear()}.${date.getMonth() +1}.${date.getDate()}`;
  return await getCurrentWeek(formattedDAte);
}

export default {
  getGroupsById,
  getCurrentWeek,
  getWeeks,
  getGroupsTimes,
  getWeekId,
  getWeekById,
  getTeachersTimes,
  getRoomsTimes,
  search
}
