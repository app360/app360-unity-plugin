//
//  A360UTypes.h
//  
//
//  Created by Tuan Tran Manh on 4/15/15.
//
//

/**
 *  App360SDK wrapper
 */

typedef const void *A360UTypeRef;

typedef const void *A360UTypeApp360SDKClientRef;

typedef const void *A360UTypeApp360SDKRef;

typedef void (*A360InitSuccess)(A360UTypeApp360SDKClientRef *client);

typedef void (*A360InitFailure)(A360UTypeApp360SDKClientRef *client, const char *error);

/**
 *  SessionManager wrapper
 */

typedef const void *A360UTypeSessionManagerClientRef;

typedef const void *A360UTypeSessionManagerRef;

typedef void (*A360SessionSuccess)(A360UTypeSessionManagerClientRef *client);

typedef void (*A360SessionFailure)(A360UTypeSessionManagerClientRef *client, const char *error);

/**
 *  ScopedUser wrapper
 */

typedef const void *A360UTypeScopedUserClientRef;

typedef const void *A360UTypeScopedUserRef;

typedef void (*A360UpdateUserSuccess)(A360UTypeScopedUserClientRef *client);

typedef void (*A360UpdateUserFailure)(A360UTypeScopedUserClientRef *client, const char *error);

/**
 *  SMSRequest wrapper
 */

typedef const void *A360UTypeSMSRequestClientRef;

typedef const void *A360UTypeSMSRequestRef;

typedef void (*A360SMSRequestSuccess)(A360UTypeSMSRequestClientRef *client, const char *transactionData);

typedef void (*A360SMSRequestFailure)(A360UTypeSMSRequestClientRef *client, const char *error);


/**
 *  CardRequest wrapper
 */

typedef const void *A360UTypeCardRequestClientRef;

typedef const void *A360UTypeCardRequestRef;

typedef void (*A360CardRequestSuccess)(A360UTypeCardRequestClientRef *client, const char *transactionData);

typedef void (*A360CardRequestFailure)(A360UTypeCardRequestClientRef *client, const char *error);


/**
 *  BankRequest wrapper
 */

typedef const void *A360UTypeBankRequestClientRef;

typedef const void *A360UTypeBankRequestRef;

typedef void (*A360BankRequestSuccess)(A360UTypeBankRequestClientRef *client, const char *transactionData);

typedef void (*A360BankRequestFailure)(A360UTypeBankRequestClientRef *client, const char *error);


/**
 *  StatusRequest wrapper
 */

typedef const void *A360UTypeStatusRequestClientRef;

typedef const void *A360UTypeStatusRequestRef;

typedef void (*A360StatusRequestSuccess)(A360UTypeStatusRequestClientRef *client, const char *transactionData);

typedef void (*A360StatusRequestFailure)(A360UTypeStatusRequestClientRef *client, const char *error);