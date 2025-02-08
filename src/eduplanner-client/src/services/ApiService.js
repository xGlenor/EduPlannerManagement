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

async function getTimes(resource, typeId, weekId, weekTypeIds) {
  const url = new URL(`/api/${resource + 's'}/times`, BASE_URL);
  url.searchParams.set(resource +'Id', typeId);
  url.searchParams.set('weekId', weekId);
  weekTypeIds.forEach(id => url.searchParams.append('weekTypeIds', id));

  const response = await fetch(url);
  const data = await response.json();

  return data;
}

async function getTeachersTimes(teacherId, weekId, weekTypeIds){
  const url = new URL('/api/teachers/times', BASE_URL);
  url.searchParams.set('teacherId', teacherId);
  url.searchParams.set('weekId', weekId);
  weekTypeIds.forEach(id => url.searchParams.append('weekTypeIds', id));
  
  const response = await fetch(url);
  const data = await response.json();
  
  return data;
}
async function getRoomsTimes(roomId, weekId, weekTypeIds){
  const url = new URL('/api/rooms/times', BASE_URL);
  url.searchParams.set('roomId', roomId);
  url.searchParams.set('weekId', weekId);
  weekTypeIds.forEach(id => url.searchParams.append('weekTypeIds', id));
  
  const response = await fetch(url);
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
  getWeekId,
  getWeekById,
  getTeachersTimes,
  getRoomsTimes,
  search,
  getTimes
}
