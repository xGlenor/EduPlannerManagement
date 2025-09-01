import {
  NavigationMenu, NavigationMenuContent,
  NavigationMenuItem,
  NavigationMenuLink,
  NavigationMenuList, NavigationMenuTrigger, navigationMenuTriggerStyle
} from "@/components/ui/navigation-menu.tsx";
import {Link} from "@tanstack/react-router";

export function NavHeader() {
  return (
    <NavigationMenu viewport={false}>
      <NavigationMenuList>
        <NavigationMenuItem>
          <NavigationMenuLink asChild className={navigationMenuTriggerStyle()}>
            <Link to="/">Strona główna</Link>
          </NavigationMenuLink>
        </NavigationMenuItem>

        <NavigationMenuItem>
          <NavigationMenuTrigger>Plany zajęć</NavigationMenuTrigger>
          <NavigationMenuContent className="whitespace-nowrap">
            <NavigationMenuLink asChild>
              <Link to="/">Grupy zajęciowe</Link>
            </NavigationMenuLink>

            <NavigationMenuLink asChild>
              <Link to="/">Nauczyciele</Link>
            </NavigationMenuLink>

            <NavigationMenuLink asChild>
              <Link to="/">Sale</Link>
            </NavigationMenuLink>
          </NavigationMenuContent>
        </NavigationMenuItem>
      </NavigationMenuList>
    </NavigationMenu>
  )
}