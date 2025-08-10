import { defineConfig } from "vite";
import path from 'path';

import tailwindcss from "@tailwindcss/vite";
import { tanstackRouter } from  '@tanstack/router-plugin/vite';
import react from "@vitejs/plugin-react";

export default defineConfig({
  base: "/",
  plugins: [
    tailwindcss(),
    tanstackRouter({ target: "react", autoCodeSplitting: true }),
    react()
  ],
  preview: {
    port: 80,
    strictPort: true,
  },
  server: {
    port: 80,
    strictPort: true,
    host: true,
    origin: "http://0.0.0.0:80",
  },
  resolve: {
    alias: {
      "@": path.resolve(__dirname, "./src"),
    },
  },
});
