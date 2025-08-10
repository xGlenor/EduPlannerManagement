import {createRoot} from 'react-dom/client'
import {App} from "@/app.tsx";
import './index.css'

const element = document.getElementById('root');
if (element) {
  createRoot(element).render(<App />)
}


