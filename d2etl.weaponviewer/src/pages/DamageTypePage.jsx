/** @import {DamageTypeDefinition} from '../../types.js' */
import {useState, useEffect} from 'react';
import DamageTypeCard from "../features/DamageTypeCard/DamageTypeCard.jsx";
import NavigationButtonGroup from "../components/NavigationButtonGroup/NavigationButtonGroup.jsx";
import RouteHeader from "../components/RouteHeader/RouteHeader.jsx";

import "./GetAllDamageType.css";

/** @type {DamageTypeDefinition} */
const initialState = {
    name: '',
    description: '',
    icon: '',
    color: {
        red: 255,
        green: 255,
        blue: 255,
        alpha: 255,
    }
}

/**
 * @name DamageTypePage
 * @returns {JSX.Element}
 * @description This is the containing page for the DamageType Route Endpoint. It
 * includes the GetAll and GetById endpoints.
 * @constructor
 */
function DamageTypePage() {
    const [allTypes, setAllTypes] = useState([]);
    const [typesById, setTypesById] = useState(initialState);

    function loadDamageTypeData() {
        fetch("http://localhost:5164/damage_type")
            .then(res => res.json())
            .then(data => {
                setAllTypes(data);
                setTypesById(data[0]);
            });
    }

    function handleOnClick(id) {
        return function (e) {
            fetch("http://localhost:5164/damage_type/" + id)
                .then(res => res.json())
                .then(data => {
                    setTypesById(data);
                });
        }
    }

    useEffect(loadDamageTypeData, []);


    function mapDamageTypes(allTypes) {
        return allTypes.map(createDamageTypeCard)
    }

    function createDamageTypeCard(item) {
        return item.name !== 'Raid'
            ? (<DamageTypeCard damageType={item}/>)
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
                <DamageTypeCard damageType={typesById}/>
            </div>
        </>)
}

export default DamageTypePage;