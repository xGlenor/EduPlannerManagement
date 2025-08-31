import {Moon, Sun, SunMoonIcon} from "lucide-react"

import {Button} from "@/components/ui/button"
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuLabel,
  DropdownMenuRadioGroup,
  DropdownMenuRadioItem,
  DropdownMenuSeparator,
  DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu"
import {type Theme, useTheme} from "@/contexts/theme-provider"
import {useTranslation} from "react-i18next";

export function ThemeToggle() {
  const {setTheme, theme} = useTheme();
  const {t} = useTranslation("theme");

  return (
    <DropdownMenu>
      <DropdownMenuTrigger asChild>
        <Button variant="outline" size="icon">
          <Sun className="h-[1.2rem] w-[1.2rem] scale-100 rotate-0 transition-all dark:scale-0 dark:-rotate-90"/>
          <Moon
            className="absolute h-[1.2rem] w-[1.2rem] scale-0 rotate-90 transition-all dark:scale-100 dark:rotate-0"/>
          <span className="sr-only">{t('change-theme')}</span>
        </Button>
      </DropdownMenuTrigger>

      <DropdownMenuContent align="end" className="min-w-52">
        <DropdownMenuLabel>
          {t("choose-theme")}
        </DropdownMenuLabel>

        <DropdownMenuSeparator/>

        <DropdownMenuRadioGroup
          value={theme}
          onValueChange={(v) => setTheme(v as Theme)}
          aria-label={t("languages")}
        >
          <DropdownMenuRadioItem value="light" className="justify-between">
            <span>{t('light')}</span>
            <Sun className="size-4"/>
          </DropdownMenuRadioItem>

          <DropdownMenuRadioItem value="dark" className="justify-between">
            <span>{t('dark')}</span>
            <Moon className="size-4"/>
          </DropdownMenuRadioItem>

          <DropdownMenuRadioItem value="system" className="justify-between">
            <span>{t('system')}</span>
            <SunMoonIcon className="size-4"/>
          </DropdownMenuRadioItem>
        </DropdownMenuRadioGroup>
      </DropdownMenuContent>
    </DropdownMenu>
  )
}