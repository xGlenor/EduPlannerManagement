import Sidebar from "./components/sidebar/Sidebar.jsx";
import {useState} from "react";
import Navbar from "./components/navbar/Navbar.jsx";

function App({Content}) {
  const [isOpen, setIsOpen] = useState(true);
  
/*  useEffect(() => {
    if (useIsMobile) {
      setIsOpen(false);
    }else
      setIsOpen(true);
  }, [])
  */
  return (
    <div className="flex">
      <Sidebar isOpen={isOpen} setIsOpen={setIsOpen} />
      <div className="w-full">
        <Navbar isOpen={isOpen} setIsOpen={setIsOpen} />
        <main className="p-7">
          <Content />
        </main>
      </div>
    </div>
  )
}

export default App
