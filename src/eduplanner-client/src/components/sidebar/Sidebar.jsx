import {Component, Fragment} from 'react';

import {Menus} from "../../lib/Menus.jsx";
import "./Sidebar.css";
import {Link} from "react-router";
import DynamicIcon from "../../lib/DynamicIcon.jsx";
import * as settings from "../../../settings.json";
import * as PropTypes from "prop-types";

class Sidebar extends Component {
  render() {
    let {isOpen} = this.props;
    
    const links = Object.entries(settings.links);
    
    return (
      <div className={`sidebar ${isOpen ? 'lg:w-72' : 'w-0 lg:w-20'}`}>
        {/* LOGO */}
        <div>
          <div className="sidebar__logo">
            <img src={`/assets/${isOpen ? 'full-logo.png' : 'small-logo.png'}`} alt="Logo"/>
          </div>
          
          
          <div className="sidebar__items__container">
            <div className={`sidebar__description`}>
              <span className={`sidebar__text ${isOpen ? '' : 'hidden'}`}>Szybki dostęp do twojego planu zajęć!</span>
              <span className="sidebar__line w-3/5 mb-0.5 "></span>
              <span className="sidebar__line w-2/5"></span>
            </div>
            <ul className={`sidebar__items ${isOpen ? '' : 'items-center'}`}>
              
              {Menus.map((item) => (
                
                <Fragment key={item.id}>
                  <li key={item.id}>
                    <Link to={item.link} className="sidebar__item">
                  <span className="sidebar__item_icon">
                    <item.Icon/>
                  </span>
                      {isOpen ? <span>{item.title}</span> : null}
                    </Link>
                  </li>
                  
                  {item.submenu && isOpen && (
                    <ul className="sidebar__subitems">
                      {item.items.map((submenu) => (
                        <li key={submenu.id}>
                          <Link to={submenu.link} className="sidebar__subitem">
                        <span className="">
                          <submenu.Icon className="size-2.5"/>
                        </span>
                            {isOpen ? <span>{submenu.title}</span> : null}
                          </Link>
                        </li>
                      ))}
                    </ul>
                  )}
                </Fragment>
              ))}
            </ul>
          </div>
        </div>
        <div
          className={`flex items-center justify-center pb-6 gap-4 ${isOpen ? 'flex-row' : 'flex-col'} block lg:hidden`}>
          {links.map((link) => {
            return (
              <Link to={link[1].url} key={link[1].index}>
                <DynamicIcon className="size-6 text-white" iconName={link[1].icon}/>
              </Link>
            )
          })}
        </div>
      </div>
    );
  }
}

Sidebar.propTypes = {
  isOpen: PropTypes.any,
  setIsOpen: PropTypes.any
}

export default Sidebar;
