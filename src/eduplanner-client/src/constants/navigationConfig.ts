import type {LinkProps} from "@tanstack/react-router";

type NavItem = Omit<LinkProps, 'children'> & {
  key: string;
  i18nKey: string;
  children?: NavItem[];
}

export const NAVIGATION_CONFIG: ReadonlyArray<NavItem> = [
  {
    key: "home",
    to: "/",
    i18nKey: "nav:home"
  },
  {
    key: "schedules",
    to: "/schedules/$resource",
    i18nKey: "nav:schedules:label",
    children: [
      {
        key: "schedules/class-group",
        to: "/schedules/$resource",
        params: { resource: 'class-groups' },
        i18nKey: "nav:schedules:classGroups"
      },
      {
        key: "schedules/teachers",
        to: "/schedules/$resource",
        params: { resource: 'teachers' },
        i18nKey: "nav:schedules:teachers"
      },
      {
        key: "schedules/rooms",
        to: "/schedules/$resource",
        params: { resource: 'rooms' },
        i18nKey: "nav:schedules:rooms"
      }
    ]
  }
] as const;