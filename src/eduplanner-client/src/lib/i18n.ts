import i18n from "i18next";
import LanguageDetector from "i18next-browser-languagedetector";
import {initReactI18next} from "react-i18next";

import en from '@/locales/en.json';
import pl from '@/locales/pl.json';

const resources = { pl, en };

i18n
  .use(LanguageDetector)
  .use(initReactI18next)
  .init({
    resources,

    supportedLngs: ['pl', 'en'],
    fallbackLng: 'pl',

    debug: import.meta.env.DEV,

    interpolation: {
      escapeValue: false
    }
  });

export default i18n;