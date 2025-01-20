/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./src/**/*.{js,jsx,ts,tsx}",
  ],
  theme: {
    extend: {
      colors: {
        'primary-dark': '#17376E',
        'primary-light': '#476CAB',
        'ubb-white': '#F1F1F1',
        'ubb-gray': '#767676',
      }
    },
  },
  plugins: [
  ],
}

