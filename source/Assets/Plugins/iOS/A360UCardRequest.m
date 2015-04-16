//
//  A360UCardRequest.m
//  App360USDK
//
//  Created by Tuan Tran Manh on 4/16/15.
//  Copyright (c) 2015 Mwork. All rights reserved.
//

#import "A360UCardRequest.h"
#import <App360SDK/App360SDK.h>

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
