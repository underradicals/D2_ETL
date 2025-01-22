import DamageTypeCard from "../features/DamageTypeCard/DamageTypeCard.jsx";
import NavigationButtonGroup from "../components/NavigationButtonGroup/NavigationButtonGroup.jsx";
import RouteHeader from "../components/RouteHeader/RouteHeader.jsx";
import useDestinyTypeOneData from "../hooks/useDestinyTypeOneData.js";

import "./GetAllDamageType.css";

/**
 * @name DamageTypePage
 * @returns {JSX.Element}
 * @description This is the containing page for the DamageType Route Endpoint. It
 * includes the GetAll and GetById endpoints.
 * @constructor
 */
function DamageTypePage() {
    const [allTypes, typesById,setTypesById] = useDestinyTypeOneData('damage_type');

    function handleOnClick(id) {
        return function (e) {
            fetch("http://localhost:5164/damage_type/" + id)
                .then(res => res.json())
                .then(data => {
                    setTypesById(data);
                });
        }
    }

    function mapDamageTypes(allTypes) {
        return allTypes.map(createDamageTypeCard)
    }

    function createDamageTypeCard(item) {
        return item.name !== 'Raid'
            ? (<DamageTypeCard  key={item.id} damageType={item}/>)
            : ('')
    }

    function createDamageTypeByIdButtonGroup(item) {
        return item.name !== 'Raid' ? (
            <button key={item.id} className={`nav-button`} data-target={item.id}
                    onClick={handleOnClick(item.id)}>{item.name}</button>
        ) : ('')
    }

    function mapDamageTypeByIdButtonList(allTypes) {
        return allTypes.map(createDamageTypeByIdButtonGroup);
    }

    return (
        <>
            <NavigationButtonGroup/>
            <RouteHeader method={`get`} route={`damage_type`}/>
            <div className={`dt-icon-container`}>
                {mapDamageTypes(allTypes)}
            </div>
            <RouteHeader method={`get`} route={`damage_type/id`}/>
            <div className={`dt-icon-container`}>
                {mapDamageTypeByIdButtonList(allTypes)}
            </div>
            <div className={`dt-icon-container`}>
                <DamageTypeCard key={typesById.id} damageType={typesById}/>
            </div>
        </>)
}

export default DamageTypePage;