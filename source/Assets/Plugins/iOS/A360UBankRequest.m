//
//  A360UBankRequest.m
//  App360USDK
//
//  Created by Tuan Tran Manh on 4/16/15.
//  Copyright (c) 2015 Mwork. All rights reserved.
//

#import "A360UBankRequest.h"
#import <App360SDK/App360SDK.h>

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
    }];
}

@end
