import * as React from 'react'
import { Outlet, createRootRoute } from '@tanstack/react-router'
import {Outlet, createRootRouteWithContext} from '@tanstack/react-router'
import {SiteHeader} from "@/components/site-header.tsx";

export const Route = createRootRoute({
export const Route = createRootRouteWithContext<{
}>()({
  component: RootComponent,
})

function RootComponent() {
  return (
    <React.Fragment>
      <div>Hello "__root"!</div>
      <Outlet />
    </React.Fragment>
    <div className="[--header-height:calc(--spacing(14))] grid grid-rows-[auto_1fr_auto] min-h-screen">
      <SiteHeader/>

      <main className="flex flex-col flex-1">
        <Outlet />
      </main>
    </div>
  )
}
