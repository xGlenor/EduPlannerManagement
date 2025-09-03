import {
  NavigationMenu, NavigationMenuContent,
  NavigationMenuItem,
  NavigationMenuLink,
  NavigationMenuList, NavigationMenuTrigger, navigationMenuTriggerStyle
} from "@/components/ui/navigation-menu.tsx";
import {Link} from "@tanstack/react-router";
import {NAVIGATION_CONFIG} from "@/constants/navigationConfig.ts";
import {useTranslation} from "react-i18next";

export function NavHeader() {
  const { t } = useTranslation();

  return (
    <NavigationMenu viewport={false}>
      <NavigationMenuList>
        {NAVIGATION_CONFIG.map(({key, i18nKey, children, ...props}) => !children ? (
            <NavigationMenuItem key={key}>
              <NavigationMenuLink asChild className={navigationMenuTriggerStyle()}>
                <Link {...props}>{t(i18nKey)}</Link>
              </NavigationMenuLink>
            </NavigationMenuItem>
          ) : (
            <NavigationMenuItem key={key}>
              <NavigationMenuTrigger>{t(i18nKey)}</NavigationMenuTrigger>
              <NavigationMenuContent className="whitespace-nowrap">
                {children.map(({key, i18nKey, ...props}) => (
                  <NavigationMenuLink key={key} asChild>
                    <Link {...props}>{t(i18nKey)}</Link>
                  </NavigationMenuLink>
                ))}
              </NavigationMenuContent>
            </NavigationMenuItem>
          ))}
      </NavigationMenuList>
    </NavigationMenu>
  )
}