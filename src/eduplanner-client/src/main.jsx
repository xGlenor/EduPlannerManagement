
import { createRoot } from 'react-dom/client'
import './index.css'
import {RouterProvider} from "react-router/dom";
import {createBrowserRouter} from "react-router";
import App from "./App.jsx";
import Index from "./pages/Index.jsx";
import GroupTree from "./pages/Groups/GroupTree.jsx";
import TeacherTree from "./pages/Teachers/TeacherTree.jsx";
import RoomTree from "./pages/Rooms/RoomTree.jsx";
import Search from "./pages/Search.jsx";
import TimesView from "./pages/Times/TimesView.jsx";

const routes = createBrowserRouter([
  {path: "/", element: <App Content={Index} />},
  
  {path: "/groupstree", element: <App Content={GroupTree} />},
  {path: "/groupstree/:id", element: <App Content={GroupTree}/>},
  {path: "/group/:typeId/week/:weekId",  element: <App Content={TimesView} />},

  {path: "/teacherstree", element: <App Content={TeacherTree} />},
  {path: "/teacherstree/:id", element: <App Content={TeacherTree} />},
  {path: "/teacher/:typeId/week/:weekId",  element: <App Content={()=><TimesView resource="teacher"/>} />},
  
  {path: "/roomstree", element: <App Content={RoomTree} />},
  {path: "/roomstree/:id", element: <App Content={RoomTree} />},
  {path: "/room/:typeId/week/:weekId",  element: <App Content={<TimesView resource="rooms"/>} />},
  
  {path: "/search(/string)",  element: <App Content={Search} />},
  
]);

createRoot(document.getElementById('root')).render(
  <RouterProvider router={routes} />
  ,
)
