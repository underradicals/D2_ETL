/** @import {NavLinkDefinition} from '../../types.js' */
import {NavLink} from "react-router";

/** @type {NavLinkDefinition[]} */
const NavLinks = [
    {
        pathname: "/",
        text: "Home",
    },
    {
        pathname: "/damage_type",
        text: "Damage Type",
    }  
]

function createNavLink(item) {
    return <NavLink to={item.pathname}>{item.text}</NavLink>
}

function mapNavLinkButtonGroup(NavLinks) {
    return NavLinks.map(createNavLink);
}

function NavigationButtonGroup(props) {
    return (
        <section className="url-button-group">
            {mapNavLinkButtonGroup(NavLinks)}
        </section>
    );
}

export default NavigationButtonGroup;