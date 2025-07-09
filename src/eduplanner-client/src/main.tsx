
import { createRoot } from 'react-dom/client'
import './index.css'
import {RouterProvider} from "react-router/dom";
import {createBrowserRouter} from "react-router";
import App from "./App.tsx";
import Index from "./pages/Index.tsx";
import GroupTree from "./pages/Groups/GroupTree.tsx";
import TeacherTree from "./pages/Teachers/TeacherTree.tsx";
import RoomTree from "./pages/Rooms/RoomTree.tsx";
import Search from "./pages/Search.tsx";
import TimesView from "./pages/Times/TimesView.tsx";

const routes = createBrowserRouter([
  {path: "/", element: <App content={<Index />} />},
  
  {path: "/groupstree", element: <App content={<GroupTree />} />},
  {path: "/groupstree/:id", element: <App content={<GroupTree />}/>},
  {path: "/group/:typeId/week/:weekId",  element: <App content={<TimesView resource="group"/>}/>},

  {path: "/teacherstree", element: <App content={<TeacherTree />} />},
  {path: "/teacherstree/:id", element: <App content={<TeacherTree />} />},
  {path: "/teacher/:typeId/week/:weekId",  element: <App content={<TimesView resource="teacher"/>} />},
  
  {path: "/roomstree", element: <App content={<RoomTree />} />},
  {path: "/roomstree/:id", element: <App content={<RoomTree />} />},
  {path: "/room/:typeId/week/:weekId",  element: <App content={<TimesView resource="room"/>} />},
  
  {path: "/search(/string)",  element: <App content={<Search />} />},
]);

const element = document.getElementById('root');
if (element) {
  createRoot(element).render(<RouterProvider router={routes} />)
}


