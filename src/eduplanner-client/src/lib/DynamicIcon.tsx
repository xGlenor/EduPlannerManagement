import * as FaIcons from "react-icons/fa6";

const DynamicIcon = ({ iconName, ...props }) => {
  const IconComponent = FaIcons?.[iconName];
  
  if (!IconComponent) {
    console.error(`Nie znaleziono ikony ${iconName} `);
    return null;
  }

  return <IconComponent {...props} />;
};

export default DynamicIcon;
