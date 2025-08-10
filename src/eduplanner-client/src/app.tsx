import {ThemeProvider} from "@/contexts/theme-provider.tsx";

import { routeTree } from '@/routeTree.gen.ts';
import {createRouter, RouterProvider} from "@tanstack/react-router";

const router = createRouter({routeTree});

declare module '@tanstack/react-router' {
  interface Register {
    router: typeof router
  }
}

export function App() {
  return (
    <ThemeProvider>
      <RouterProvider router={router} />
    </ThemeProvider>
  )
}