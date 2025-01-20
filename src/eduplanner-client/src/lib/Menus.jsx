import {FaCalendarAlt, FaCircle, FaHome, FaInfoCircle} from "react-icons/fa";

export const Menus = [
  {id: 1, title: "Plan Zajęć", link: "/", Icon: FaCalendarAlt,
    submenu: true,
    items: [
      {id: 2, title: "Grupy", link: "/groups", Icon: FaCircle},
      {id: 3, title: "Nauczyciele", link: "/teachers", Icon: FaCircle},
      {id: 4, title: "Sale", link: "/rooms", Icon: FaCircle}
    ]
  },
  {id: 5, title: "Strona Główna", link: "https://ubb.edu.pl/", Icon: FaHome},
  {id: 6, title: "Informacje", link: "/", Icon: FaInfoCircle },
];
