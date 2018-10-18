using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebApiFileUpload.DesktopClient.MercadoModels.Erros
{
    public class BadRequest : BaseMercadoError
    {
        private static List<ErrorApiResponse> errorApis;

        public List<ErrorApiResponse> ErrorApis
        {
            get
            {
                if (errorApis == null)
                    errorApis = ChargeErrorApi();
                return errorApis;
            }

            set
            {
                errorApis = value;
            }
        }

        public override string Canhandle(Hashtable htable)
        {
                Hashtable response= ((Hashtable)htable["response"]);
                return ErrorApis.FirstOrDefault(t => t.Error.Trim().ToLower() == response["error"].ToString().Trim().ToLower()
                && t.ApiMessage== response["message"].ToString().Trim().ToLower() && t.Status== htable["status"].ToString().Trim().ToLower())
                    .Message;
        }

        public override string Message()
        {
            throw new NotImplementedException();
        }



        private List<ErrorApiResponse> ChargeErrorApi()
        {
            errorApis = new List<ErrorApiResponse>();
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_collector_id",
                InternalCode = 1,
                ApiMessage = "collector_id must be a number",
                Message = "El id del coleccionista debe ser un número",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_collector_id",
                InternalCode = 2,
                ApiMessage = "collector_id invalid",
                Message = "El id del coleccionista es inválido",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_sponsor_id",
                InternalCode = 3,
                ApiMessage = "sponsor_id not found",
                Message = "El id del sponsor no se encuentra",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_sponsor_id",
                InternalCode = 4,
                ApiMessage = "sponsor_id must be a number",
                Message = "El id del sponsor debe ser un número",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_sponsor_id",
                InternalCode = 5,
                ApiMessage = "sponsor_id should be different than collector_id",
                Message = "El id del sponsor debe ser diferente al id del coleccionista",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_sponsor_id",
                InternalCode = 6,
                ApiMessage = "sponsor_id site must be the same as collector_id",
                Message = "El id del sitio del sponsor debe ser el mismo al id del coleccionista",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_sponsor_id",
                InternalCode = 7,
                ApiMessage = "sponsor_id didn't accept MercadoPago's Terms and Conditions",
                Message = "El id del sponsor no aceptó los terminos y condiciones",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_sponsor_id",
                InternalCode = 8,
                ApiMessage = "sponsor_id is not an active user",
                Message = "El id del sponsor no es un usuario activo",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_collector_email",
                InternalCode = 9,
                ApiMessage = "collector is not collector_email(secure) owner",
                Message = "El coleccionista no tiene un email seguro de propietario",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_collector_email",
                InternalCode = 10,
                ApiMessage = "collector is not collector_email owner",
                Message = "El coleccionista no tiene un email de propietario",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_operation_type",
                InternalCode = 11,
                ApiMessage = "operation_type invalid",
                Message = "Tipo de operación inválida",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_expiration_date_to",
                InternalCode = 12,
                ApiMessage = "expiration_date_to invalid",
                Message = "Fecha de expiración hasta inválida",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_expiration_date_from",
                InternalCode = 13,
                ApiMessage = "invalid_expiration_date_from",
                Message = "Fecha de expiración desde inválida",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_items",
                InternalCode = 15,
                ApiMessage = "amount cannot be paid with MercadoPago",
                Message = "Esa cantidad no puede ser pagada con MercadoPago",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_items",
                InternalCode = 16,
                ApiMessage = "items needed",
                Message = "Debe cargar items",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_items",
                InternalCode = 17,
                ApiMessage = "items invalid. Wrong format",
                Message = "Items inválidos, formato incorrecto",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_items",
                InternalCode = 18,
                ApiMessage = "currency_id needed",
                Message = "Se requiere el Id de la moneda",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_items",
                InternalCode = 19,
                ApiMessage = "currency_id invalid",
                Message = "El Id de la moneda es inválido",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_items",
                InternalCode = 20,
                ApiMessage = "quantity needed",
                Message = "No ha ingresado la cantidad",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_items",
                InternalCode = 21,
                ApiMessage = "quantity must be a number",
                Message = "La cantidad debe ser un número",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_items",
                InternalCode = 22,
                ApiMessage = "quantity must be a number",
                Message = "La cantidad debe ser un número",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_items",
                InternalCode = 23,
                ApiMessage = "unit_price needed",
                Message = "Ingrese el precio unitario",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_items",
                InternalCode = 24,
                ApiMessage = "unit_price must be a number",
                Message = "El precio unitario debe ser un número",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_items",
                InternalCode = 25,
                ApiMessage = "unit_price invalid",
                Message = "Precio unitario inválido",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_items",
                InternalCode = 26,
                ApiMessage = "unit_price invalid",
                Message = "Precio unitario inválido",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_payer",
                InternalCode = 27,
                ApiMessage = "payer invalid. Wrong format",
                Message = "Comprador inválido, formato incorrecto",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_payer",
                InternalCode = 28,
                ApiMessage = "payer name invalid. Max length 100",
                Message = "Nombre del comprador inválido, longitud máxima de 100",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_payer",
                InternalCode = 29,
                ApiMessage = "payer surname invalid. Max length 100",
                Message = "Apellido del comprador inválido, longitud máxima de 100",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_payer",
                InternalCode = 30,
                ApiMessage = "payer email invalid. Max length 150",
                Message = "Email del comprador inválido, longitud máxima de 150",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_back_urls",
                InternalCode = 31,
                ApiMessage = "back_urls invalid. Wrong format",
                Message = "Urls de vuelta inválidas, formato incorrecto",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_payment_methods",
                InternalCode = 32,
                ApiMessage = "payment_methods invalid. Wrong format",
                Message = "Métodos de pago inválidos, formao incorrecto",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_payment_methods",
                InternalCode = 33,
                ApiMessage = "the combination of payment methods and payment types cannot exclude all payment methods",
                Message = "La combinación de métodos de pago y tipos de pagos no pueden excluir todos los metodos de pago",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_payment_methods",
                InternalCode = 34,
                ApiMessage = "amount cannot be paid with MercadoPago",
                Message = "Esa cantidad no puede ser pagada por MercadoPago",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_payment_methods",
                InternalCode = 35,
                ApiMessage = "excluded_payment_methods invalid. Wrong format",
                Message = "Metodos de pago excluídos inválidos, formato incorrecto",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_payment_methods",
                InternalCode = 36,
                ApiMessage = "id needed",
                Message = "Se requiere el id",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_payment_methods",
                InternalCode = 37,
                ApiMessage = "account_money cannot be excluded",
                Message = "account_money no puede ser excluída",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_payment_methods",
                InternalCode = 38,
                ApiMessage = "cannot exclude all payments methods",
                Message = "No se puede excluir todos los métodos de pago",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_payment_methods",
                InternalCode = 39,
                ApiMessage = "excluded_payment_types invalid. Wrong format",
                Message = "Tipos de pagos excluídos inválidos, formato incorrecto",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_payment_methods",
                InternalCode = 40,
                ApiMessage = "cannot exclude all payments types",
                Message = "No puede excluir todos los tipos de pagos",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_payment_methods",
                InternalCode = 41,
                ApiMessage = "client_id invalid",
                Message = "Id del cliente inválido",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_payment_methods",
                InternalCode = 42,
                ApiMessage = "client_id must be a number",
                Message = "El id del cliente debe ser un número",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_installments",
                InternalCode = 43,
                ApiMessage = "installments invalid. Should be only 1, 3, 6, 9, 12, 15, 18, 21 or 24",
                Message = "Cuotas inválidas. Debe ser solo 1, 3, 6, 9, 12, 15, 18, 21 o 24",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_installments",
                InternalCode = 44,
                ApiMessage = "installments must be a number",
                Message = "Cuotas debe ser un número",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_marketplace_fee",
                InternalCode = 45,
                ApiMessage = "marketplace_fee must be a number",
                Message = "La cuota del mercado debe ser un número",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_marketplace_fee",
                InternalCode = 46,
                ApiMessage = "marketplace_fee must be a positive number",
                Message = "La cuota del mercado debe ser un número positivo",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_marketplace_fee",
                InternalCode = 47,
                ApiMessage = "marketplace_fee must not be greater than total amount",
                Message = "La cuota del mercado no debe ser un mayor al total",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_id",
                InternalCode = 48,
                ApiMessage = "preference_id not found",
                Message = "El id de la preferencia no se encontró",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_access_token",
                InternalCode = 49,
                ApiMessage = "access denied",
                Message = "Acceso denegado",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_shipments",
                InternalCode = 50,
                ApiMessage = "access denied",
                Message = "Acceso denegado",
                Status = "400"
            });
            //Shipments not found

            // 404 Not Found
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "2000",
                InternalCode = 51,
                ApiMessage = "Payment not found",
                Message = "No se encontró el pago",
                Status = "404"
            });

            // 403 Forbidden
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "4",
                InternalCode = 52,
                ApiMessage = "The caller is not authorized to access this resource",
                Message = "No está autorizado para acceder a este recurso",
                Status = "403"
            });

            errorApis.Add(new ErrorApiResponse()
            {
                Error = "2041",
                InternalCode = 53,
                ApiMessage = "Only admin users can perform the requested action",
                Message = "Sólo los administradores pueden acceder a esta acción",
                Status = "403"
            });

            errorApis.Add(new ErrorApiResponse()
            {
                Error = "3002",
                InternalCode = 54,
                ApiMessage = "The caller is not authorized to perform this action",
                Message = "El llamador no está autorizado para ejercer esta acción",
                Status = "403"
            });

            // Bad Request Production

            errorApis.Add(new ErrorApiResponse()
            {
                Error = "1",
                InternalCode = 50,
                ApiMessage = "Params Error",
                Message = "Error de parámetros",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "3",
                InternalCode = 50,
                ApiMessage = "Token must be for test",
                Message = "Se requiere token para probar",
                Status = "400"
            });



            errorApis.Add(new ErrorApiResponse()
            {
                Error = "5",
                InternalCode = 50,
                ApiMessage = "Must provide your access_token to proceed",
                Message = "Se requiere el token de acceso para proceder",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "1000",
                InternalCode = 50,
                ApiMessage = "Number of rows exceeded the limits",
                Message = "Número de registros exceden los límites",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "1001",
                InternalCode = 50,
                ApiMessage = "Date format must be yyyy-MM-dd'T'HH:mm:ss.SSSZ",
                Message = "El formato debe ser yyyy-MM-dd'T'HH:mm:ss.SSSZ",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "2001",
                InternalCode = 50,
                ApiMessage = "Already posted the same request in the last minute",
                Message = "Ya ha hecho la misma solicitud en el último minuto",
                Status = "400"

            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "2004",
                InternalCode = 50,
                ApiMessage = "POST to Gateway Transactions API fail",
                Message = "La solicitud y la transacción en la puerta de enlace de la API falló",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "2002",
                InternalCode = 50,
                ApiMessage = "Customer not found",
                Message = "El cliente no se encuentra",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "2006",
                InternalCode = 50,
                ApiMessage = "Card Token not found",
                Message = "No se encontró el token de las tarjetas de créditos",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "2007",
                InternalCode = 50,
                ApiMessage = "Connection to Card Token API fail",
                Message = "La conexón para retornar el token de las tarjetas de crédito falló",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "2009",
                InternalCode = 50,
                ApiMessage = "Card token isssuer can't be null",
                Message = "El token de las tarjetas de crédito del editor no puede ser nulo",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "2010",
                InternalCode = 50,
                ApiMessage = "Card not found",
                Message = "Tarjeta de crédito no encontrada",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "2013",
                InternalCode = 50,
                ApiMessage = "Invalid profileId",
                Message = "Id de perfil inválido",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "2013",
                InternalCode = 50,
                ApiMessage = "Invalid profileId",
                Message = "Id de perfil inválido",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "2013",
                InternalCode = 50,
                ApiMessage = "Invalid profileId",
                Message = "Id de perfil inválido",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "2013",
                InternalCode = 50,
                ApiMessage = "Invalid profileId",
                Message = "Id de perfil inválido",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "2013",
                InternalCode = 50,
                ApiMessage = "Invalid profileId",
                Message = "Id de perfil inválido",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "2013",
                InternalCode = 50,
                ApiMessage = "Invalid profileId",
                Message = "Id de perfil inválido",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "2014",
                InternalCode = 50,
                ApiMessage = "Invalid reference_id",
                Message = "Id de referencia inválida",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "2015",
                InternalCode = 50,
                ApiMessage = "Invalid scope",
                Message = "Alcance-Scope Inválido",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "2016",
                InternalCode = 50,
                ApiMessage = "Invalid status for update",
                Message = "Status inválido para modificar",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "2017",
                InternalCode = 50,
                ApiMessage = "Invalid transaction_amount for update",
                Message = "Cantidad de la Transacción inválida para modificar",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "2018",
                InternalCode = 50,
                ApiMessage = "The action requested is not valid for the current payment state",
                Message = "La acción solicitada no es válida para el estado de pago actual",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "2020",
                InternalCode = 50,
                ApiMessage = "Customer not allowed to operate",
                Message = "Cliente no permitido para operar",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "2021",
                InternalCode = 50,
                ApiMessage = "Collector not allowed to operate",
                Message = "No se permite operar a ese coleccionista",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "2022",
                InternalCode = 50,
                ApiMessage = "You have exceeded the max number of refunds for this payment",
                Message = "Has excedido el número maximo de reembolsos por este pago",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "2024",
                InternalCode = 50,
                ApiMessage = "Payment too old to be refunded",
                Message = "El pago es demasiado viejo para utilizar el reembolso",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "2025",
                InternalCode = 50,
                ApiMessage = "Operation type not allowed to be refunded",
                Message = "El tipo de operación no es permitida para utilizar reembolso",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "2027",
                InternalCode = 50,
                ApiMessage = "The action requested is not valid for the current payment method type",
                Message = "La acción solicitada no es válida para el método de pago actual",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "2029",
                InternalCode = 50,
                ApiMessage = "Payment without movements",
                Message = "Pago sin movimientos",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "2030",
                InternalCode = 50,
                ApiMessage = "Collector hasn't enough money",
                Message = "El coleccionista no posee más dinero",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "2031",
                InternalCode = 50,
                ApiMessage = "Collector hasn't enough available money",
                Message = "El coleccionista ya no posee más dinero",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "2034",
                InternalCode = 50,
                ApiMessage = "Invalid users involved",
                Message = "Usuario involucrado inválido",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "2035",
                InternalCode = 50,
                ApiMessage = "Invalid params for preference Api",
                Message = "Parámetros inválidos para la preferencia de la API",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "2036",
                InternalCode = 50,
                ApiMessage = "Invalid context",
                Message = "Contexto inválido",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "2038",
                InternalCode = 50,
                ApiMessage = "Invalid campaign_id",
                Message = "Id de campaña inválido",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "2039",
                InternalCode = 50,
                ApiMessage = "Invalid coupon_code",
                Message = "Código de cupón inválido",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "2040",
                InternalCode = 50,
                ApiMessage = "User email doesn't exist",
                Message = "El Email de usuario no existe",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "2060",
                InternalCode = 50,
                ApiMessage = "The customer can't be equal to the collector",
                Message = "El cliente no es el mismo que el coleccionista",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "3000",
                InternalCode = 50,
                ApiMessage = "You must provide your cardholder_name with your card data",
                Message = "Debes especificar tú nombre que aparece en la tarjeta con los datos de tu tarjeta",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "3001",
                InternalCode = 50,
                ApiMessage = "You must provide your cardissuer_id with your card data",
                Message = "Debes especificar el id de la tarjeta con los datos de tarjeta",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "3003",
                InternalCode = 50,
                ApiMessage = "Invalid card_token_id",
                Message = "Token Id de la tarjeta inválido",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "3004",
                InternalCode = 50,
                ApiMessage = "Invalid parameter site_id",
                Message = "Parámetro site_id inválido",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "3005",
                InternalCode = 50,
                ApiMessage = "Not valid action, the resource is in a state that does not allow this operation. For more information see the state that has the resource.",
                Message = "Acción no válida, el recurso está en un estado que no es posible para operación solicitada, para más información mire el estado del recurso",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "3006",
                InternalCode = 50,
                ApiMessage = "Invalid parameter cardtoken_id",
                Message = "Parámetro inválido del card_token_id",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "3007",
                InternalCode = 50,
                ApiMessage = "The parameter client_id can not be null or empty",
                Message = "El parámetro id_cliente no puede ser nulo o estar vacío",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "3009",
                InternalCode = 50,
                ApiMessage = "Not found Cardtoken",
                Message = "Client id no autorizado",
                Status = "400"

            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "3010",
                InternalCode = 50,
                ApiMessage = "Not found card on whitelist",
                Message = "No se ha encontrado la tarjeta en la whitelist",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "3011",
                InternalCode = 50,
                ApiMessage = "Not found payment_method",
                Message = "No se ha encontrado el método de pago",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "3012",
                InternalCode = 50,
                ApiMessage = "Invalid parameter security_code_length",
                Message = "Parámetro security_code_lenght inválido",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "3013",
                InternalCode = 50,
                ApiMessage = "The parameter security_code is a required field can not be null or empty",
                Message = "El parámetro security_code es un campo requerido y no puede ser nulo o estar vacío",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "3014",
                InternalCode = 50,
                ApiMessage = "Invalid parameter payment_method",
                Message = "Parámetro inválido en el metodo de pago",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "3015",
                InternalCode = 50,
                ApiMessage = "Invalid parameter card_number_length",
                Message = "Parámetro inválido en la longitud del número de tarjeta de crédito",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "3016",
                InternalCode = 50,
                ApiMessage = "Invalid parameter card_number",
                Message = "Parámetro inválido en el número de tarjeta",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "3017",
                InternalCode = 50,
                ApiMessage = "The parameter card_number_id can not be null or empty",
                Message = "El parámetro card_number_id no puede ser nulo o estar vacío",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "3018",
                InternalCode = 50,
                ApiMessage = "The parameter expiration_month can not be null or empty",
                Message = "El parámetro mes de expiración no puede ser nulo o vacío",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "3019",
                InternalCode = 50,
                ApiMessage = "The parameter expiration_year can not be null or empty",
                Message = "El parámetro año de expiración no puede ser nulo o vacío",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "3020",
                InternalCode = 50,
                ApiMessage = "The parameter cardholder.name can not be null or empty",
                Message = "El parámetro nombre de titular de tarjeta no puede ser nulo o vacío",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "3021",
                InternalCode = 50,
                ApiMessage = "The parameter cardholder.document.number can not be null or empty",
                Message = "El parámetro número de documento en la tarjeta de crédito no puede ser nulo o vacío",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "3022",
                InternalCode = 50,
                ApiMessage = "The parameter cardholder.document.type can not be null or empty",
                Message = "El parámetro tipo de documento no puede ser nulo o vacío",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "3023",
                InternalCode = 50,
                ApiMessage = "The parameter cardholder.document.subtype can not be null or empty",
                Message = "El parámetro subtipo de documento de tarjeta de crédito no debe ser nulo o vacío",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "3024",
                InternalCode = 50,
                ApiMessage = "Not valid action - partial refund unsupported for this transaction",
                Message = "Acción no válida- Reembolso parcial no soportado para esta transacción",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "3025",
                InternalCode = 50,
                ApiMessage = "Invalid Auth Code",
                Message = "Código de autentificación inválido",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "3026",
                InternalCode = 50,
                ApiMessage = "Invalid card_id for this payment_method_id",
                Message = "Card_Id inválido para este payment_method_id",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "3027",
                InternalCode = 50,
                ApiMessage = "Invalid payment_type_id",
                Message = "Id de tipo de pago inválido",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "3028",
                InternalCode = 50,
                ApiMessage = "Invalid payment_method_id",
                Message = "Id de método de pago inválido",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "3029",
                InternalCode = 50,
                ApiMessage = "Invalid card expiration month",
                Message = "Mes de expiración de la tarjeta inválido",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "3030",
                InternalCode = 50,
                ApiMessage = "Invalid card expiration year",
                Message = "Año de expiración de la tarjeta inválida",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "4000",
                InternalCode = 50,
                ApiMessage = "card atributte can't be null",
                Message = "Atributo tarjeta no puede ser nulo",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "4001",
                InternalCode = 50,
                ApiMessage = "payment_method_id atributte can't be null",
                Message = "payment_method_id atribute no debe ser nulo",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "4002",
                InternalCode = 50,
                ApiMessage = "transaction_amount atributte can't be null",
                Message = "Atributo de cantidad de la transacción no debe ser nulo",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "4003",
                InternalCode = 50,
                ApiMessage = "transaction_amount atributte must be numeric",
                Message = "Atributo de cantidad de la transacción debe ser numérico",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "4004",
                InternalCode = 50,
                ApiMessage = "installments atributte can't be null",
                Message = "El atributo cuotas no debe ser nulo",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "4005",
                InternalCode = 50,
                ApiMessage = "installments atributte must be numeric",
                Message = "El atributo cuotas no debe ser numérico",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "4006",
                InternalCode = 50,
                ApiMessage = "payer atributte is malformed",
                Message = "El atributo pagador está malformado",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "4007",
                InternalCode = 50,
                ApiMessage = "site_id atributte can't be null",
                Message = "Atributo site_id no puede ser nulo",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "4012",
                InternalCode = 50,
                ApiMessage = "payer.id atributte can't be null",
                Message = "Atributo pagador_id no puede ser nulo",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "4013",
                InternalCode = 50,
                ApiMessage = "payer.type atributte can't be null",
                Message = "Atributo tipo_pagador no puede ser nulo",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "4015",
                InternalCode = 50,
                ApiMessage = "payment_method_reference_id atributte can't be null",
                Message = "Atributo payment_method_reference_id no puede ser nulo",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "4016",
                InternalCode = 50,
                ApiMessage = "payment_method_reference_id atributte must be numeric",
                Message = "Atributo payment_method_reference_id debe ser numérico",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "4017",
                InternalCode = 50,
                ApiMessage = "status atributte can't be null",
                Message = "Atributo estado no puede ser nulo",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "4018",
                InternalCode = 50,
                ApiMessage = "payment_id atributte can't be null",
                Message = "Atributo payment_id no puede ser nulo",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "4019",
                InternalCode = 50,
                ApiMessage = "payment_id atributte must be numeric",
                Message = "Atributo payment_id debe ser numérico",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "4020",
                InternalCode = 50,
                ApiMessage = "notificaction_url atributte must be url valid",
                Message = "Atributo de notificación de la url debe ser una url válida",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "4021",
                InternalCode = 50,
                ApiMessage = "notificaction_url atributte must be shorter than 500 character",
                Message = "Atributo de notificación de la url debe ser más corta de 500 caracteres",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "4022",
                InternalCode = 50,
                ApiMessage = "metadata atributte must be a valid JSON",
                Message = "Atributo de metadatos deben ser en formato JSON",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "4023",
                InternalCode = 50,
                ApiMessage = "transaction_amount atributte can't be null",
                Message = "El atributo de la cantidad de la transacción no puede ser nulo",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "4024",
                InternalCode = 50,
                ApiMessage = "transaction_amount atributte must be numeric",
                Message = "El atributo de la cantidad de la transacción debe ser un número",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "4025",
                InternalCode = 50,
                ApiMessage = "refund_id can't be null",
                Message = "Refund_id no debe ser nulo",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "4026",
                InternalCode = 50,
                ApiMessage = "Invalid coupon_amount",
                Message = "Cantidad de cupon inválido",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "4027",
                InternalCode = 50,
                ApiMessage = "campaign_id atributte must be numeric",
                Message = "El atributo campaing_id debe ser un número",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "4028",
                InternalCode = 50,
                ApiMessage = "coupon_amount atributte must be numeric",
                Message = "El atributo cantidad de cupon debe ser un número",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "4029",
                InternalCode = 50,
                ApiMessage = "Invalid payer type",
                Message = "Tipo de pagador inválido",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "4037",
                InternalCode = 50,
                ApiMessage = "Invalid transaction_amount",
                Message = "Cantidad de transacción inválida",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "4038",
                InternalCode = 50,
                ApiMessage = "application_fee cannot be bigger than transaction_amount",
                Message = "La cuota no debe ser más grande que el monto de la transacción",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "4039",
                InternalCode = 50,
                ApiMessage = "application_fee cannot be a negative value",
                Message = "La cuota no debe ser un número negativo",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "4050",
                InternalCode = 50,
                ApiMessage = "payer.email must be a valid email",
                Message = "El email del pagador debe ser un mail válido",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "4051",
                InternalCode = 50,
                ApiMessage = "payer.email must be shorter than 254 characters",
                Message = "El email del pagador debe ser más corto que 254 caracteres",
                Status = "400"
            });

            return errorApis;
        }
    }
}
