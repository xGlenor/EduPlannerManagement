import {NavHeader} from '@/components/nav-header.tsx';
import {Button} from "@/components/ui/button.tsx";
import {Separator} from "@/components/ui/separator.tsx";
import {ThemeToggle} from "@/components/theme-toggle.tsx";
import {LanguageToggle} from "@/components/language-toggle.tsx";
import {Link} from "@tanstack/react-router";

export function SiteHeader() {
  return (
    <header className="bg-background/50  sticky top-0 z-50 flex w-full items-center border-b">
      <div className="container mx-auto flex h-(--header-height) w-full items-center gap-2 px-4">
        <Button
          asChild
          variant="ghost"
        >
          <Link to="/">
            TUTAJ LOGO
          </Link>
        </Button>

        <NavHeader />

        <div className="ml-auto flex flex-wrap items-center gap-2">
          <LanguageToggle />

          <Separator orientation="vertical" />
          <ThemeToggle />
        </div>
      </div>
    </header>
  )
}