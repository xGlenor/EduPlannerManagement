import "./Navbar.css";
import {FaBars} from "react-icons/fa";
import * as settings from '../../../settings.json';
import {Link} from "react-router";

import DynamicIcon from "../../lib/DynamicIcon.tsx";
import Search from "../Search.tsx";

export type NavbarProps = {
    isOpen: boolean;
    setIsOpen: (isOpen: boolean) => void;
}

const Navbar = ({isOpen, setIsOpen}: NavbarProps) => {
    const links = Object.entries(settings.links);

    return (
        <div className="h-20 shadow-xl">
            <div className="w-full h-full flex items-center justify-between px-8 ">
                <div className="flex gap-8 text-primary-dark font-bold">
                    <FaBars
                        className={`text-primary-dark size-6 duration-500 cursor-pointer ${isOpen ? '' : 'rotate-180'}`}
                        onClick={() => setIsOpen(!isOpen)}/>
                    <p className="hidden lg:block">Rok: {settings.main.year} | {settings.main.semester}</p>
                </div>
                <div className="flex gap-8">
                    <Search/>
                    <div className=" items-center gap-4 hidden lg:flex">
                        {links.map((link) => {
                            return (
                                <Link to={link[1].url} key={link[1].index}>
                                    <DynamicIcon className="size-6 text-primary-dark" iconName={link[1].icon}/>
                                </Link>
                            )
                        })}
                    </div>
                </div>
            </div>

        </div>
    );
}

export default Navbar;
