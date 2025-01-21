/**
 * @typedef RouteHeaderProps
 * @property {string} method
 * @property {RouteHeaderValues} route
 */


/**
 * @typedef NavLinkDefinition
 * @property {string} pathname
 * @property {string} text
 */

/**
 * @typedef Color
 * @property {number} red
 * @property {number} green
 * @property {number} blue
 * @property {number} alpha
 */


/**
 * @typedef DamageTypeDefinition
 * @property {string} name
 * @property {string} description
 * @property {string} icon
 * @property {Color} color
 */


/**
 * @typedef DamageTypeProps
 * @property {DamageTypeDefinition} damageType
 */



/**
 * @readonly
 * @enum {string}
 */
const RouteHeaderValues = {
    GET: 'GET',
    POST: 'POST',
    PUT: 'PUT',
    DELETE: 'DELETE',
    OPTIONS: 'OPTIONS',
    HEAD: 'HEAD',
    CONNECT: 'CONNECT',
    TRACE: 'TRACE',
    PATCH: 'PATCH',
}

export default {}