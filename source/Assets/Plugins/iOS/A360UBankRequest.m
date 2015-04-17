//
//  A360UBankRequest.m
//  App360USDK
//
//  Created by Tuan Tran Manh on 4/16/15.
//  Copyright (c) 2015 Mwork. All rights reserved.
//

#import "A360UBankRequest.h"
#import <App360SDK/App360SDK.h>
#import "A360UConstants.h"
#import "NSDictionary+JSON.h"

@implementation A360UBankRequest

- (instancetype)initWithClient:(A360UTypeBankRequestClientRef *)client
{
    self = [super init];
    if (self) {
        _client = client;
    }
    return self;
}

- (void)requestTransactionWithAmount:(int)amount payload:(NSString *)payload
{
    [MOGPaymentSDK makeBankingTransactionWithAmount:amount payload:payload block:^(MOGBankingResponseObject *responseObject, NSError *error) {
        //TODO: Call callback method
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
            [json setObject:kTypeSMS forKey:kType];
            [json setObject:responseObject.payURL.absoluteString forKey:kCardCode];
            
            NSString *amount = responseObject.details[kAmount];
            if (amount) {
                [json setObject:amount forKey:kAmount];
            }
            
            self.successCallback(self.client, [[(NSDictionary *)json toJSONString] UTF8String]);
        }
    }];
}

@end
