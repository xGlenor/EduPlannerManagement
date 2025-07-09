import Sidebar from "./components/sidebar/Sidebar.tsx";
import {useState} from "react";
import Navbar from "./components/navbar/Navbar.tsx";

export type AppProps = {
    content: React.ReactNode;
}

function App({content}: AppProps) {
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
            <Sidebar isOpen={isOpen} setIsOpen={setIsOpen}/>
            <div className="w-full">
                <Navbar isOpen={isOpen} setIsOpen={setIsOpen}/>
                <main className="p-7">
                    {content}
                </main>
            </div>
        </div>
    )
}

export default App
