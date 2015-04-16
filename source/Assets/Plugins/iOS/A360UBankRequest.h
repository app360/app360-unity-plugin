//
//  A360UBankRequest.h
//  App360USDK
//
//  Created by Tuan Tran Manh on 4/16/15.
//  Copyright (c) 2015 Mwork. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "A360UTypes.h"

@interface A360UBankRequest : NSObject

@property (nonatomic, assign) A360UTypeBankRequestClientRef *client;

@property (nonatomic, assign) A360BankRequestSuccess successCallback;

@property (nonatomic, assign) A360BankRequestFailure failureCallback;

- (instancetype)initWithClient:(A360UTypeBankRequestClientRef *)client;

- (void)requestTransactionWithAmount:(int)amount payload:(NSString *)payload;

@end
