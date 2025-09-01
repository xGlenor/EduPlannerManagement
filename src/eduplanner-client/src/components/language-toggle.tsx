import { Globe } from "lucide-react";
import { useTranslation } from "react-i18next";

import { Button } from "@/components/ui/button";
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuTrigger,
  DropdownMenuLabel,
  DropdownMenuSeparator,
  DropdownMenuRadioGroup,
  DropdownMenuRadioItem,
} from "@/components/ui/dropdown-menu";

const LOCALES = [
  { code: "pl", label: "Polski" },
  { code: "en", label: "English" },
] as const;

type LocaleCode = typeof LOCALES[number]["code"];

export function LanguageToggle() {
  const { t, i18n } = useTranslation("lngs");
  const change = (lng: LocaleCode) => {
    if (lng !== i18n.language) {
      i18n.changeLanguage(lng);
    }
  };

  return (
    <DropdownMenu>
      <DropdownMenuTrigger asChild>
        <Button
          variant="outline"
          size="icon"
          aria-label={t("change-lng")}
          data-testid="language-toggle-btn"
        >
          <Globe className="size-4" aria-hidden="true" />
          <span className="sr-only">{t("change-lng")}</span>
        </Button>
      </DropdownMenuTrigger>

      <DropdownMenuContent align="end" className="min-w-52">
        <DropdownMenuLabel>
          {t("choose-lng")}
        </DropdownMenuLabel>

        <DropdownMenuSeparator />

        <DropdownMenuRadioGroup
          value={i18n.language}
          onValueChange={(v) => change(v as LocaleCode)}
          aria-label={t("languages")}
        >
          {LOCALES.map((lng) => (
            <DropdownMenuRadioItem
              key={lng.code}
              value={lng.code}
              className="justify-between"
            >
              <span>{lng.label}</span>
              <span className="ml-2 text-muted-foreground">
                ({t(lng.code)})
              </span>
            </DropdownMenuRadioItem>
          ))}
        </DropdownMenuRadioGroup>
      </DropdownMenuContent>
    </DropdownMenu>
  );
}
