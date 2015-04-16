//
//  A360UCardRequest.h
//  App360USDK
//
//  Created by Tuan Tran Manh on 4/16/15.
//  Copyright (c) 2015 Mwork. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "A360UTypes.h"

@interface A360UCardRequest : NSObject

@property (nonatomic, assign) A360UTypeCardRequestClientRef *client;

@property (nonatomic, assign) A360CardRequestSuccess successCallback;

@property (nonatomic, assign) A360CardRequestFailure failureCallback;

- (instancetype)initWithClient:(A360UTypeCardRequestClientRef *)client;

- (void)requestTransactionWithVendor:(NSString *)vendor
                            cardCode:(NSString *)cardCode
                          cardSerial:(NSString *)cardSerial
                             payload:(NSString *)payload;

@end
