//
//  A360UStatusRequest.h
//  App360USDK
//
//  Created by Tuan Tran Manh on 4/17/15.
//  Copyright (c) 2015 Mwork. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "A360UTypes.h"

@interface A360UStatusRequest : NSObject

@property (nonatomic, assign) A360UTypeStatusRequestClientRef *client;

@property (nonatomic, assign) A360StatusRequestSuccess successCallback;

@property (nonatomic, assign) A360StatusRequestFailure failureCallback;

- (instancetype)initWithClient:(A360UTypeStatusRequestClientRef *)client;

- (void)requestTransactionId:(NSString *)transactionId;

@end
