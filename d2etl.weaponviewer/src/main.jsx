import {StrictMode} from 'react'
import {createRoot} from 'react-dom/client'
import {BrowserRouter, Routes, Route} from 'react-router';
import './index.css'
import App from './App.jsx'
import MainLayout from "./layouts/MainLayout.jsx";
import GetAllDamageType from "./pages/DamageTypePage.jsx";
import ErrorBoundary from "./pages/ErrorBoundary.jsx";

export default function Main() {
    return (
        <StrictMode>
            <BrowserRouter>
                <Routes>
                    <Route
                        path="/"
                        element={<MainLayout title={`D2 API`}/>}
                        errorElement={<ErrorBoundary error={`404 not found`}/>}
                    >
                        <Route index element={<App/>}/>
                    </Route>
                    <Route path="/damage_type" element={<MainLayout title={`Damage Types`}/>}>
                        <Route index element={<GetAllDamageType/>}/>
                    </Route>
                </Routes>
            </BrowserRouter>
        </StrictMode>
    )
}

createRoot(document.getElementById('root')).render(<Main/>)
