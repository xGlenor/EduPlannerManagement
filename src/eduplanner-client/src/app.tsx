import {ThemeProvider} from "@/contexts/theme-provider.tsx";
import {routeTree} from '@/routeTree.gen.ts';
import {createRouter, RouterProvider} from "@tanstack/react-router";
import {QueryClient, QueryClientProvider} from "@tanstack/react-query";
import "@/lib/i18n";

const queryClient = new QueryClient();

const router = createRouter({
  routeTree,

  context: {
    queryClient,
  },

  defaultPreload: 'intent',
  defaultPreloadStaleTime: 0,
  scrollRestoration: true,
});

declare module '@tanstack/react-router' {
  interface Register {
    router: typeof router
  }
}

export function App() {
  return (
    <QueryClientProvider client={queryClient}>
      <ThemeProvider>
        <RouterProvider router={router}/>
      </ThemeProvider>
    </QueryClientProvider>
  )
}