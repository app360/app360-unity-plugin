//
//  A360UStatusRequest.m
//  App360USDK
//
//  Created by Tuan Tran Manh on 4/17/15.
//  Copyright (c) 2015 Mwork. All rights reserved.
//

#import "A360UStatusRequest.h"
#import <App360SDK/App360SDK.h>
#import "A360UConstants.h"
#import "NSDictionary+JSON.h"

@implementation A360UStatusRequest

- (instancetype)initWithClient:(A360UTypeStatusRequestClientRef *)client
{
    self = [super init];
    if (self) {
        _client = client;
    }
    return self;
}

- (void)requestTransactionId:(NSString *)transactionId
{
    [MOGPaymentSDK checkStatusOfTransaction:transactionId block:^(MOGPaymentResponseObject *responseObject, NSError *error) {
        
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
            
            NSString *type = nil;
            switch (responseObject.type) {
                case MOGTransactionTypeSMS:
                {
                    type = kTypeSMS;
                    [json setObject:responseObject.details[kAmount] forKey:kAmount];
                    
                    NSString *command = responseObject.details[kCommand];
                    if (command) {
                        NSString *ott = responseObject.details[kOTT];
                        [json setObject:[NSString stringWithFormat:@"%@ %@", command, ott] forKey:kSyntax];
                        
                        NSString *recipient = responseObject.details[kShortCode];
                        [json setObject:recipient forKey:kRecipient];
                    }
                }
                    break;
                case MOGTransactionTypeBank:
                {
                    type = kTypeBank;
                    NSString *amount = responseObject.details[kAmount];
                    if (amount) {
                        [json setObject:amount forKey:kAmount];
                    }
                }
                    break;
                case MOGTransactionTypeCard:
                default:
                {
                    type = kTypeCard;
                    NSString *vendor = responseObject.details[kCardType];
                    NSString *cardCode = responseObject.details[kPin];
                    NSString *cardSerial = responseObject.details[kSerial];
                    
                    [json setObject:vendor forKey:kVendor];
                    [json setObject:cardCode forKey:kCardCode];
                    [json setObject:cardSerial forKey:kCardSerial];
                }
                    break;
            }
            
            [json setObject:type forKey:kType];
            
            self.successCallback(self.client, [[(NSDictionary *)json toJSONString] UTF8String]);
        }
        
        
    }];
}

@end
