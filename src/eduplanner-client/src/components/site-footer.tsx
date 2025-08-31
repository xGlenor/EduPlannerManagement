import {Trans, useTranslation} from "react-i18next";

export function SiteFooter() {
  const { t } = useTranslation("footer");

  return (
    <footer className="text-muted-foreground text-xs text-end mx-auto container py-3">
      <p>{t('createdBy')}</p>

      <Trans
        t={t}
        i18nKey="sourceCode"
        components={[
          <a
            href="https://github.com/xGlenor/EduPlannerManagement"
            target="_blank"
            rel="noreferrer"
            className="font-medium underline underline-offset-4"
          />
        ]}
      />

      <p>{t('rights')}</p>
    </footer>
  )
}