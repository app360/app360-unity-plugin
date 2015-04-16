//
//  A360USMSRequest.h
//  App360USDK
//
//  Created by Tuan Tran Manh on 4/16/15.
//  Copyright (c) 2015 Mwork. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "A360UTypes.h"

@interface A360USMSRequest : NSObject

@property (nonatomic, assign) A360UTypeSMSRequestClientRef *client;

@property (nonatomic, assign) A360SMSRequestSuccess successCallback;

@property (nonatomic, assign) A360SMSRequestFailure failureCallback;

- (instancetype)initWithClient:(A360UTypeSMSRequestClientRef *)client;

- (void)requestTransactionWithAmount:(NSString *)amount payload:(NSString *)payload;

@end
