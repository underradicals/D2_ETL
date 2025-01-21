import { Outlet } from 'react-router';
import "./MainLayout.css";
function MainLayout({title}) {
    return (
        <>
            <header className="layout-header">
                <h2 className='layout-header--title'>{title}</h2>
            </header>
            <main>
                <Outlet/>
            </main>
        </>
    )
}

export default MainLayout;