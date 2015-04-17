//
//  A360UCardRequest.m
//  App360USDK
//
//  Created by Tuan Tran Manh on 4/16/15.
//  Copyright (c) 2015 Mwork. All rights reserved.
//

#import "A360UCardRequest.h"
#import <App360SDK/App360SDK.h>
#import "A360UConstants.h"
#import "NSDictionary+JSON.h"

@implementation A360UCardRequest

- (instancetype)initWithClient:(A360UTypeCardRequestClientRef *)client
{
    self = [super init];
    if (self) {
        _client = client;
    }
    return self;
}

- (void)requestTransactionWithVendor:(NSString *)vendor
                            cardCode:(NSString *)cardCode
                          cardSerial:(NSString *)cardSerial
                             payload:(NSString *)payload
{
    MOGVendor cardVendor = [self vendorFromString:vendor];
    [MOGPaymentSDK makePhoneCardTransactionWithVendor:cardVendor cardCode:cardCode cardSerial:cardSerial payload:payload block:^(MOGCardResponseObject *responseObject, NSError *error) {
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
            [json setObject:responseObject.cardCode forKey:kCardCode];
            [json setObject:responseObject.cardSerial forKey:kCardSerial];
            
            NSString *vendorName = nil;
            switch (responseObject.vendor) {
                case MOGVendorViettel:
                    vendorName = kVendorViettel;
                    break;
                case MOGVendorMobifone:
                    vendorName = kVendorMobifone;
                    break;
                case MOGVendorVinaphone:
                    vendorName = kVendorVinaphone;
                    break;
                default:
                    vendorName = kVendorViettel;
                    break;
            }
            [json setObject:vendorName forKey:kVendor];
            
            self.successCallback(self.client, [[(NSDictionary *)json toJSONString] UTF8String]);
        }
            
    }];
}

- (MOGVendor)vendorFromString:(NSString *)vendorString
{
    vendorString = [vendorString lowercaseString];
    if ([vendorString isEqualToString:@"viettel"]) {
        return MOGVendorViettel;
    } else if ([vendorString isEqualToString:@"vinaphone"]) {
        return MOGVendorVinaphone;
    } else {
        return MOGVendorMobifone;
    }
}

@end
