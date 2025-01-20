import "./Navbar.css";
import {FaBars, FaSearch} from "react-icons/fa";
import * as settings from '../../../settings.json';
import {Link} from "react-router";

import DynamicIcon from "../../lib/DynamicIcon.jsx";
import * as PropTypes from "prop-types";
import {Component} from "react";

class Navbar extends Component {
  render() {
    let {isOpen, setIsOpen} = this.props;
    
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
            <div className="flex items-center rounded-2xl bg-ubb-white gap-3 px-4 py-2">
              <FaSearch className="text-ubb-gray text-lg block float-left cursor-pointer"/>
              <input type={"search"} className="bg-transparent outline-none w-auto text-ubb-gray"
                     placeholder={"Szukaj..."}/>
            </div>
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
}

Navbar.propTypes = {
  isOpen: PropTypes.any,
  setIsOpen: PropTypes.any
}

export default Navbar;
