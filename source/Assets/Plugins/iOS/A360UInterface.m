//
//  A360UInterface.m
//  App360USDK
//
//  Created by Tuan Tran Manh on 4/15/15.
//  Copyright (c) 2015 Mwork. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "A360UApp360SDK.h"
#import "A360USessionManager.h"
#import "A360UScopedUser.h"
#import "A360UObjectCache.h"
#import "A360USMSRequest.h"
#import "A360UCardRequest.h"
#import "A360UBankRequest.h"
#import "A360UTypes.h"

static NSString * NSStringFromUTF8String(const char *bytes)
{
    if (bytes) {
        return @(bytes);
    } else {
        return nil;
    }
}

// Helper method to create C string copy
static char* MakeStringCopy (const char* string)
{
    if (string == NULL)
        return NULL;
    
    char* res = (char*)malloc(strlen(string) + 1);
    strcpy(res, string);
    return res;
}

#pragma mark - App360SDK

A360UTypeApp360SDKRef createApp360SDKObject(A360UTypeApp360SDKClientRef *client)
{
    A360UApp360SDK *app360sdk = [[A360UApp360SDK alloc] initWithClient:client];
    A360UObjectCache *cache = [A360UObjectCache sharedInstance];
    [cache.references setObject:app360sdk forKey:[app360sdk a360u_referenceKey]];
    return (__bridge A360UTypeApp360SDKRef)app360sdk;
}

void setInitCallback(A360UTypeApp360SDKRef app360sdk, A360InitSuccess onSuccess, A360InitFailure onFailure)
{
    A360UApp360SDK *app360sdkObj = (__bridge A360UApp360SDK *)app360sdk;
    app360sdkObj.successCallback = onSuccess;
    app360sdkObj.failureCallback = onFailure;
}

void initialize(A360UTypeApp360SDKRef app360sdk, const char *appId, const char *appSecret)
{
    A360UApp360SDK *app360sdkObj = (__bridge A360UApp360SDK *)app360sdk;
    [app360sdkObj initialize:NSStringFromUTF8String(appId) appSecret:NSStringFromUTF8String(appSecret)];
}

const char * getChannel()
{
    NSString *channel = [A360UApp360SDK getChannel];
    return MakeStringCopy([channel UTF8String]);
}

const char * getSubChannel()
{
    NSString *subChannel = [A360UApp360SDK getSubChannel];
    return MakeStringCopy([subChannel UTF8String]);
}

const char * getNativeSDKVersion()
{
    NSString *sdkVersion = [A360UApp360SDK getSDKVersion];
    return MakeStringCopy([sdkVersion UTF8String]);
}

#pragma mark - SessionManager

A360UTypeSessionManagerRef createSessionManagerObject(A360UTypeSessionManagerClientRef *client)
{
    A360USessionManager *manager = [[A360USessionManager alloc] initWithClient:client];
    return (__bridge A360UTypeSessionManagerRef)manager;
}

void setSessionCallback(A360UTypeSessionManagerRef manager, A360SessionSuccess onSuccess, A360SessionFailure onFailure)
{
    A360USessionManager *sessionManager = (__bridge A360USessionManager *)manager;
    sessionManager.successCallback = onSuccess;
    sessionManager.failureCallback = onFailure;
}

void createSession(A360UTypeSessionManagerRef manager, const char *scopedid)
{
    A360USessionManager *sessionManager = (__bridge A360USessionManager *)manager;
    [sessionManager createSessionWithScopedId:NSStringFromUTF8String(scopedid)];
}

void createSessionWithService(A360UTypeApp360SDKRef manager, const char *service, const char *token)
{
    A360USessionManager *sessionManager = (__bridge A360USessionManager *)manager;
    [sessionManager createSessionWithService:NSStringFromUTF8String(service) token:NSStringFromUTF8String(token)];
}

#pragma mark - ScopedUser

A360UTypeScopedUserRef createScopedUserObject(A360UTypeScopedUserClientRef *client)
{
    A360UScopedUser *scopedUser = [[A360UScopedUser alloc] initWithClient:client];
    return (__bridge A360UTypeScopedUserRef)scopedUser;
}

void setScopedUserCallback(A360UTypeScopedUserRef scopedUser, A360UpdateUserSuccess onSuccess, A360UpdateUserFailure onFailure)
{
    A360UScopedUser *user = (__bridge A360UScopedUser *)scopedUser;
    user.successCallback = onSuccess;
    user.failureCallback = onFailure;
}

const char * getUserScopedId()
{
    NSString *scopedId = [A360UScopedUser getScopedId];
    return MakeStringCopy([scopedId UTF8String]);
}

const char * getUserChannel()
{
    NSString *channel = [A360UScopedUser getChannel];
    return MakeStringCopy([channel UTF8String]);
}

const char * getUserSubChannel()
{
    NSString *subChannel = [A360UScopedUser getSubChannel];
    return MakeStringCopy([subChannel UTF8String]);
}

void linkFacebook(A360UTypeScopedUserRef scopedUser, const char *token)
{
    A360UScopedUser *user = (__bridge A360UScopedUser *)scopedUser;
    [user linkFacebookWithToken:NSStringFromUTF8String(token)];
}

void linkGoogle(A360UTypeScopedUserRef scopedUser, const char *token)
{
    A360UScopedUser *user = (__bridge A360UScopedUser *)scopedUser;
    [user linkGoogleWithToken:NSStringFromUTF8String(token)];
}

void unlinkFacebook(A360UTypeScopedUserRef scopedUser)
{
    A360UScopedUser *user = (__bridge A360UScopedUser *)scopedUser;
    [user unlinkWithFacebook];
}

void unlinkGoogle(A360UTypeScopedUserRef scopedUser)
{
    A360UScopedUser *user = (__bridge A360UScopedUser *)scopedUser;
    [user unLinkWithGoogle];
}

#pragma mark - SMSRequest

A360UTypeSMSRequestRef createSMSRequestObject(A360UTypeSMSRequestClientRef *client)
{
    A360USMSRequest *request = [[A360USMSRequest alloc] initWithClient:client];
    A360UObjectCache *cache = [A360UObjectCache sharedInstance];
    [cache.references setObject:request forKey:[request a360u_referenceKey]];
    return (__bridge A360UTypeSMSRequestRef)request;
}

void setSMSRequestCallback(A360UTypeSMSRequestRef request, A360SMSRequestSuccess onSuccess, A360SMSRequestFailure onFailure)
{
    A360USMSRequest *smsRequest = (__bridge A360USMSRequest *)request;
    smsRequest.successCallback = onSuccess;
    smsRequest.failureCallback = onFailure;
}

void requestSMSTransaction(A360UTypeSMSRequestRef request, const char *amount, const char *payload)
{
    A360USMSRequest *smsRequest = (__bridge A360USMSRequest *)request;
    [smsRequest requestTransactionWithAmount:NSStringFromUTF8String(amount) payload:NSStringFromUTF8String(payload)];
}

#pragma mark - CardRequest

A360UTypeCardRequestRef createCardRequestObject(A360UTypeCardRequestClientRef *client)
{
    A360UCardRequest *request = [[A360UCardRequest alloc] initWithClient:client];
    A360UObjectCache *cache = [A360UObjectCache sharedInstance];
    [cache.references setObject:request forKey:[request a360u_referenceKey]];
    return (__bridge A360UTypeCardRequestRef)request;
}

void setCardRequestCallback(A360UTypeCardRequestRef request, A360CardRequestSuccess onSuccess, A360CardRequestFailure onFailure)
{
    A360UCardRequest *cardRequest = (__bridge A360UCardRequest *)request;
    cardRequest.successCallback = onSuccess;
    cardRequest.failureCallback = onFailure;
}

void requestCardTransaction(A360UTypeCardRequestRef request, const char *vendor, const char *cardCode, const char *cardSerial, const char *payload)
{
    A360UCardRequest *cardRequest = (__bridge A360UCardRequest *)request;
    [cardRequest requestTransactionWithVendor:NSStringFromUTF8String(vendor)
                                     cardCode:NSStringFromUTF8String(cardCode)
                                   cardSerial:NSStringFromUTF8String(cardSerial)
                                      payload:NSStringFromUTF8String(payload)];
}

#pragma mark - BankRequest

A360UTypeBankRequestRef createBankRequestObject(A360UTypeBankRequestClientRef *client)
{
    A360USMSRequest *request = [[A360USMSRequest alloc] initWithClient:client];
    A360UObjectCache *cache = [A360UObjectCache sharedInstance];
    [cache.references setObject:request forKey:[request a360u_referenceKey]];
    return (__bridge A360UTypeSMSRequestRef)request;
}

void setBankRequestCallback(A360UTypeBankRequestRef request, A360BankRequestSuccess onSuccess, A360BankRequestFailure onFailure)
{
    A360UBankRequest *bankRequest = (__bridge A360UBankRequest *)request;
    bankRequest.successCallback = onSuccess;
    bankRequest.failureCallback = onFailure;
}

void requestBankTransaction(A360UTypeBankRequestRef request, int amount, const char *payload)
{
    A360UBankRequest *bankRequest = (__bridge A360UBankRequest *)request;
    [bankRequest requestTransactionWithAmount:amount payload:NSStringFromUTF8String(payload)];
}

#pragma mard - Common

void A360URelease(A360UTypeRef ref) {
    if (ref) {
        A360UObjectCache *cache = [A360UObjectCache sharedInstance];
        [cache.references removeObjectForKey:[(__bridge NSObject *)ref a360u_referenceKey]];
    }
}
