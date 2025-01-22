/** @import {NavLinkDefinition} from '../../types.js' */
import {NavLink} from "react-router";

/** @type {NavLinkDefinition[]} */
const NavLinks = [
    {
        id: 1,
        pathname: "/",
        text: "Home",
    },
    {
        id: 2,
        pathname: "/damage_type",
        text: "Damage Type",
    },
    {
        id: 3,
        pathname: "/ammo_type",
        text: "Ammo Type",
    }
]

function createNavLink(item) {
    return <NavLink key={item.id} to={item.pathname}>{item.text}</NavLink>
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