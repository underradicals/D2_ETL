/** @import {RouteHeaderProps} from '../../../types.js' */
import "./RouteHeader.css";

/**
 * @name RouteHeader
 * @param {RouteHeaderProps} props
 * @returns {JSX.Element}
 * @description Encapsulates an HTTP verb and a route to the API resource
 * @constructor
 */
function RouteHeader({method, route}) {
    return (
        <h5 className={`route-path`}>
            <span className={`route-path--method`}>{method}:&emsp;</span>
            <span className={`route-path--route`}>/{route}</span>
        </h5>
    )
}

export default RouteHeader;