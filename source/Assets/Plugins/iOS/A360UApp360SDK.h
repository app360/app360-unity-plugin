//
//  A360UApp360SDKWrapper.h
//  
//
//  Created by Tuan Tran Manh on 4/15/15.
//
//

#import <Foundation/Foundation.h>
#import "A360UTypes.h"

@interface A360UApp360SDK : NSObject

@property (nonatomic, assign) A360UTypeApp360SDKClientRef *client;

@property (nonatomic, assign) A360InitSuccess successCallback;

@property (nonatomic, assign) A360InitFailure failureCallback;

- (id)initWithClient:(A360UTypeApp360SDKClientRef *)client;

- (void)initialize:(NSString *)appId appSecret:(NSString *)appSecret;

+ (NSString *)getChannel;

+ (NSString *)getSubChannel;

+ (NSString *)getSDKVersion;

@end
