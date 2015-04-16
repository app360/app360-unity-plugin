//
//  A360USMSRequest.m
//  App360USDK
//
//  Created by Tuan Tran Manh on 4/16/15.
//  Copyright (c) 2015 Mwork. All rights reserved.
//

#import "A360USMSRequest.h"
#import <App360SDK/App360SDK.h>

@implementation A360USMSRequest

- (instancetype)initWithClient:(A360UTypeSMSRequestClientRef *)client
{
    self = [super init];
    if (self) {
        _client = client;
    }
    return self;
}

- (void)requestTransactionWithAmount:(NSString *)amount payload:(NSString *)payload
{
    MOGSMSAmount smsAmount = [A360USMSRequest amountFromString:amount];
    [MOGPaymentSDK getSMSSyntaxWithSMSAmount:smsAmount payload:payload block:^(MOGSMSResponseObject *responseObject, NSError *error) {
        //TODO: Call callback method
    }];
}

+ (MOGSMSAmount)amountFromString:(NSString *)amountString
{
    if ([amountString isEqualToString:@"500"]) {
        return MOGSMSAmount500;
    }
    if ([amountString isEqualToString:@"1000"]) {
        return MOGSMSAmount1000;
    }
    if ([amountString isEqualToString:@"2000"]) {
        return MOGSMSAmount2000;
    }
    if ([amountString isEqualToString:@"3000"]) {
        return MOGSMSAmount3000;
    }
    if ([amountString isEqualToString:@"4000"]) {
        return MOGSMSAmount4000;
    }
    if ([amountString isEqualToString:@"5000"]) {
        return MOGSMSAmount5000;
    }
    if ([amountString isEqualToString:@"10000"]) {
        return MOGSMSAmount10000;
    }
    if ([amountString isEqualToString:@"15000"]) {
        return MOGSMSAmount15000;
    }
    return MOGSMSAmount15000;
}

@end
