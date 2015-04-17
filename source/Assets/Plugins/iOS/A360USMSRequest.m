//
//  A360USMSRequest.m
//  App360USDK
//
//  Created by Tuan Tran Manh on 4/16/15.
//  Copyright (c) 2015 Mwork. All rights reserved.
//

#import "A360USMSRequest.h"
#import <App360SDK/App360SDK.h>
#import "A360UConstants.h"
#import "NSDictionary+JSON.h"

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
        
        if (error) {
            if (self.failureCallback) {
                self.failureCallback(self.client, [error.description UTF8String]);
            }
        } else {
            
            if (!self.successCallback) {
                return;
            }
            
            NSMutableDictionary *json = [[NSMutableDictionary alloc] init];
            [json setObject:responseObject.payload forKey:kPayload];
            [json setObject:responseObject.transactionId forKey:kTransactionId];
            NSString *status = nil;
            switch (responseObject.status) {
                case MOGTransactionStatusBegin:
                    status = kStatusBegin;
                    break;
                case MOGTransactionStatusCompleted:
                    status = kStatusCompleted;
                    break;
                case MOGTransactionStatusFailed:
                    status = kStatusFailed;
                    break;
                case MOGTransactionStatusPending:
                    status = kStatusPending;
                    break;
                default:
                    status = kStatusBegin;
                    break;
            }
            [json setObject:status forKey:kStatus];
            NSMutableArray *services = [[NSMutableArray alloc] initWithCapacity:responseObject.services.count];
            for (MOGSMSItem *item in responseObject.services) {
                NSDictionary *smsitem = [[NSDictionary alloc] initWithObjectsAndKeys:item.recipient, kTo, item.amount, kAmount, nil];
                [services addObject:smsitem];
            }
            [json setObject:services forKey:kServices];
            [json setObject:kTypeSMS forKey:kType];
            [json setObject:responseObject.syntax forKey:kSyntax];
            [json setObject:responseObject.details[kAmount] forKey:kAmount];
            
            NSString *command = responseObject.details[kCommand];
            if (command) {
                NSString *ott = responseObject.details[kOTT];
                [json setObject:[NSString stringWithFormat:@"%@ %@", command, ott] forKey:kSyntax];
                
                NSString *recipient = responseObject.details[kShortCode];
                [json setObject:recipient forKey:kRecipient];
            }
            
            
            self.successCallback(self.client, [[(NSDictionary *)json toJSONString] UTF8String]);
        }
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
