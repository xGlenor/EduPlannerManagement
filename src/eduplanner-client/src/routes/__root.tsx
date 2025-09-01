import {Outlet, createRootRouteWithContext} from '@tanstack/react-router'
import {SiteHeader} from "@/components/site-header.tsx";
import {SiteFooter} from "@/components/site-footer.tsx";
import type {QueryClient} from "@tanstack/react-query";


export const Route = createRootRouteWithContext<{
  queryClient: QueryClient
}>()({
  component: RootComponent,
})

function RootComponent() {
  return (
    <div className="[--header-height:calc(--spacing(14))] grid grid-rows-[auto_1fr_auto] min-h-screen">
      <SiteHeader/>

      <main className="flex flex-col flex-1">
        <Outlet/>
      </main>

      <SiteFooter/>
    </div>
  )
}
