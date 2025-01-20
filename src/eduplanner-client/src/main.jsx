import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import {RouterProvider} from "react-router/dom";
import {createBrowserRouter} from "react-router";
import App from "./App.jsx";
import Groups from "./pages/Groups/Groups.jsx";
import Index from "./pages/Index.jsx";
import Teachers from "./pages/Teachers/Teachers.jsx";
import Rooms from "./pages/Rooms/Rooms.jsx";

const routes = createBrowserRouter([
  {path: "/", element: <App Content={Index} />},
  {path: "/groups", element: <App Content={Groups} />},
  {path: "/teachers", element: <App Content={Teachers} />},
  {path: "/rooms", element: <App Content={Rooms} />},
]);

createRoot(document.getElementById('root')).render(
  <StrictMode>
    <RouterProvider router={routes} />
  </StrictMode>,
)
